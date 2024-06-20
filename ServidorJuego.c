#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>
#include <stdlib.h>
#include <time.h>

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

//-----------------------------------------------------------------------------------------------------------------------//
//------------------------------------------------- ESTRUCTURAS ---------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------------//

typedef struct {
    char nombre[2000];
    int socket;	
	int enSala;
} Conectado;

typedef struct {
    Conectado listaConectado[500];
    int num;
} ListaConectados;

typedef struct {
	char id[2000];  
	char jugadores[2000];
	int num;	
} Invitacion;

typedef struct {
	Invitacion listaInvitaciones[500]; 
	int num;
} ListaInvitaciones;

typedef struct {
    int Id;
    Conectado listaPartida[500];
    int num;
} Partida;

typedef struct {
    Partida listaPartidas[500];
    int num;
} ListaPartidas;

char ubicacion[20];
int i = 0;
int sockets[100];
int turno = 1;

ListaConectados listaConect;
ListaInvitaciones listaInvita;
ListaPartidas listaParti;

void InicializarListas() {
	listaConect.num = 0;
	listaParti.num = 0;
	listaInvita.num = 0;
}
//-----------------------------------------------------------------------------------------------------------------------//
//-------------------------------------------------- FUNCIONES ----------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------------//


//-----------------------------------------------------------------------------------------------------------------------//
//------------------------------------------------- CONECTADOS ----------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------------//


int AnadirConectado(ListaConectados *lista, char nombre[20], int socket) 
{
    if (lista->num == 500) return -1; 
	else 
	{
        strcpy(lista->listaConectado[lista->num].nombre, nombre);
        lista->listaConectado[lista->num].socket = socket;
		lista->listaConectado[lista->num].enSala = 0;
        lista->num++;
		printf("Usuario '%s' a�adido a la lista de conectados.\n", nombre);
		printf("N�mero de usuarios conectados: %d\n", lista->num);
        return 0; 
    }
}

int DamePosicionConectado(ListaConectados *lista, char nombre[20]) 
{
	for (int i = 0; i < lista->num; i++) 
	{
		if (strcmp(lista->listaConectado[i].nombre, nombre) == 0) return i;
	}
	return -1;
}

int EliminarConectado(ListaConectados *lista, char nombre[20]) {
	int pos = DamePosicionConectado(lista, nombre);
	if (pos == -1 || pos >= lista->num) // Verifica si la posicion es valida
		return -1;
	else 
	{
		for (int i = pos; i < lista->num - 1; i++) 
		{ 
			lista->listaConectado[i] = lista->listaConectado[i + 1];
		}
		lista->num--;
		printf("Usuario '%s' eliminado de la lista de conectados.\n", nombre);
		printf("Numero de usuarios conectados: %d\n", lista->num);
		return 0;
	}
}

int DameConectados(ListaConectados *lista, char listaConectado[300]) 
{
	strcpy(listaConectado, "");
	char nombreFormateado[50];
	int n;
	for (int i = 0; i < lista->num; i++) 
	{		
		sprintf(nombreFormateado, "%s/", lista->listaConectado[i].nombre);
		strcat(listaConectado, nombreFormateado);
		n = i;
	}
	printf("Usuarios conectados: '%s'\n", listaConectado);
	printf("\n");
	return n;
}

void EnviarConectados(char mensaje[500]) 
{
	char conectados[512];   
	char connected[512];
	
	int n = DameConectados(&listaConect, conectados);
	
	sprintf(mensaje, "6/%s", conectados);
	printf("Mensaje lista de conectados: %s\n", mensaje);
	strcpy(connected, conectados);
	char *pi = strtok(connected, "/");
	int i = 0;
	while (pi != NULL && i < n) 
	{
		char nombre[50]; 
		strncpy(nombre, pi, sizeof(nombre) - 1); 
		nombre[sizeof(nombre) - 1] = '\0';
		pi = strtok(NULL, "/");
		i++;
	}
}

int EstaConectado(ListaConectados *lista, char nombreUsuario[20]) 
{
    for (int i = 0; i < lista->num; i++) 
	{
        if (strcmp(lista->listaConectado[i].nombre, nombreUsuario) == 0) return 0;
    }
    return -1;
}

int Dame_Socket(ListaConectados *lista, char nombre[20]) 
{
    for (int i = 0; i < lista->num; i++) {
        if (strcmp(lista->listaConectado[i].nombre, nombre) == 0) return lista->listaConectado[i].socket;
    }
    return -1;
}

//-----------------------------------------------------------------------------------------------------------------------//
//-------------------------------------------------- INVITADOS ----------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------------//

void PonerEnSala(ListaConectados *lista, char nombre[2000]){	
	int pos = DamePosicionConectado(lista, nombre);
	lista->listaConectado[pos].enSala = 1;
}

void QuitarEnSala(ListaConectados *lista, char nombre[2000]){
	int pos = DamePosicionConectado(lista, nombre);
	lista->listaConectado[pos].enSala = 0;	
}

int EstaEnUnaSala(ListaConectados *lista, char nombre[2000])
{
	int pos = DamePosicionConectado(lista, nombre);
	return lista->listaConectado[pos].enSala;
}

int CrearSala(ListaInvitaciones *lista, ListaConectados *lista2, char nombre[2000])
{
	int estaEnUnaSala = EstaEnUnaSala(lista2, nombre);
	if(estaEnUnaSala == 1){
		printf("El usuario '%s' ya esta en una sala.\n", nombre);
		return -1;	
	}
	printf("Sala creada con exito: '%s'\n", nombre);	
	strcpy(lista->listaInvitaciones[lista->num].id, nombre);
	sprintf(lista->listaInvitaciones[lista->num].jugadores, "%s-", nombre);
	PonerEnSala(lista2, nombre);
	lista->listaInvitaciones[lista->num].num = 1;
	lista->num++;	
	return 1;
}

int VerSala(ListaInvitaciones *lista, char invitador[2000], char jugadores[2000])
{
	int pos;
	for (int i = 0; i < lista->num; i++) 
	{
		if(strcmp(lista->listaInvitaciones[i].id, invitador)==0) pos = i;
	}	
	strcpy(jugadores, lista->listaInvitaciones[pos].jugadores);
	return lista->listaInvitaciones[pos].num;
}

int EstaEnLaSala(ListaInvitaciones *lista, char admin[2000], char invitado[2000])
{
	char jugadores[2000];
	char jugadores2[2000];
	VerSala(lista, admin, jugadores);
	strcpy(jugadores2, jugadores);
	
	char *p = strtok(jugadores2, "-");
	while (p != NULL) 
	{
		if(strcmp(p, invitado) == 0) return 1;
		p = strtok(NULL, "-");
	}	
	return -1;
}

int AnadirASala(ListaInvitaciones *lista, ListaConectados *lista2, char invitador[2000], char invitado[2000])
{
	int estaEnLaSala = EstaEnLaSala(lista, invitador, invitado);
	if(estaEnLaSala == 1) return -1; // Invitado ya esta en la sala.
	
	int pos;
	for (int i = 0; i < lista->num; i++) 
	{
		if(strcmp(lista->listaInvitaciones[i].id, invitador)==0) pos = i;
	}	
	
	if(lista->listaInvitaciones[pos].num <4)
	{
		sprintf(lista->listaInvitaciones[pos].jugadores, "%s%s-", lista->listaInvitaciones[pos].jugadores, invitado);		
		lista->listaInvitaciones[pos].num++;
		PonerEnSala(lista2, invitado);
		return 1;
	}	
	else return 0; // La sala est� llena
}

int EliminarSala(ListaInvitaciones *lista, ListaConectados *lista2, char nombre[2000])
{
	int pos;
	for (int i = 0; i < lista->num; i++) 
	{
		pos = i;
		if(strcmp(lista->listaInvitaciones[i].id, nombre)==0)
		{			
			char jugadores[2000];
			char jugadores2[2000];
			VerSala(lista, nombre, jugadores);
			strcpy(jugadores2, jugadores);
			char *p = strtok(jugadores2, "-");
			while(p!= NULL){
				QuitarEnSala(lista2, p);
				p = strtok(NULL, "-");				
			}
			
			for (int i = pos; i < lista->num - 1; i++) 
			{ 
				lista->listaInvitaciones[i] = lista->listaInvitaciones[i + 1];
			}
			lista->num--;
			printf("Sala eliminada con exito: '%s'\n", nombre);					
			return 1;
		}
	}	
	return -1;	
}

int AbandonarSala(ListaInvitaciones *lista, ListaConectados *lista2, char nombre[2000], char nombreSala[2000])
{
	int estaEnLaSala = EstaEnLaSala(lista, nombreSala, nombre);
	if(estaEnLaSala == 1){
		int pos;
		for (int i = 0; i < lista->num; i++) 
		{
			pos = i;
			if(strcmp(lista->listaInvitaciones[i].id, nombreSala)==0)
			{		
				printf("'%s' ha abandonado la sala con exito: \n", nombre);			
				lista->listaInvitaciones[pos].num--;
							
				char jugador[200];
				char jugadores[2000];
				char listaJugadores[2000];
				VerSala(&listaInvita, nombreSala, jugadores);
				strcpy(listaJugadores, jugadores);
				sprintf(jugador, "%s-",nombre);
				
				char *posi = strstr(listaJugadores, jugador); // Encuentra la subcadena en la cadena original

				if (posi != NULL) {
					size_t len = strlen(jugador);
					size_t len_cadena = strlen(listaJugadores);

					
					memmove(posi, posi + len, len_cadena - len - (posi - listaJugadores) + 1);
				}
				strcpy(lista->listaInvitaciones[i].jugadores, listaJugadores);
				QuitarEnSala(lista2, nombre);		
				return 1;
			}
		}	
	}
	return -1;	
}

int SalaLlena(ListaInvitaciones *lista, char admin[2000])
{
	int pos;
	for (int i = 0; i < lista->num; i++) 
	{
		if(strcmp(lista->listaInvitaciones[i].id, admin)==0) pos = i;
	}			
	if(lista->listaInvitaciones[pos].num >= 4) return 1;
	else return 0;
}

int EsAdmin(ListaInvitaciones *lista, char nombre[2000]){
	for (int i = 0; i < lista->num; i++) 
	{
		if (strcmp(lista->listaInvitaciones[i].id, nombre) == 0) return 1;
	}
	return 0;
}

int Dame_Sockets_Sala(ListaInvitaciones *lista, ListaConectados *lista2, char id[200], char Sockets_Jugadores[400], char jugadores[2000]) 
{
	int pos = -1;
	int nJugadores = 0;    
	
	for (int i = 0; i < lista->num; i++) 
	{
		if (strcmp(lista->listaInvitaciones[i].id, id) == 0) pos = i;
	}
	
	if (pos == -1) 
	{
		printf("No se encontr� la invitaci�n con id %s\n", id);
		return -1;
	}
	
	strcpy(jugadores, lista->listaInvitaciones[pos].jugadores);
	
	char jugadores2[2000];
	strcpy(jugadores2, jugadores);
	
	char *p = strtok(jugadores, "-");
	while (p != NULL) 
	{
		nJugadores++;
		p = strtok(NULL, "-");
	}	
	char Sockets_Jugadores_Sala[400] = "";
	char *l = strtok(jugadores2, "-");
	int sock = Dame_Socket(lista2, l);
	sprintf(Sockets_Jugadores_Sala, "%d", sock);
	l = strtok(NULL, "-");
	
	for (int i = 0; i < nJugadores; i++) 
	{
		if (l == NULL) break;		
		sock = Dame_Socket(lista2, l);
		sprintf(Sockets_Jugadores_Sala, "%s-%d", Sockets_Jugadores_Sala, sock);
		l = strtok(NULL, "-");
	}
	
	strcpy(Sockets_Jugadores, Sockets_Jugadores_Sala);
	
	return nJugadores;
}

int Dame_Numero_Jugadores_Sala(ListaInvitaciones *lista, char id[200], int *nJugadores) 
{
    int pos = -1;
    
    // Buscar la invitaci�n en la lista de invitaciones
    for (int i = 0; i < lista->num; i++) 
    {
        if (strcmp(lista->listaInvitaciones[i].id, id) == 0) 
        {
            pos = i;
            break; // No es necesario seguir buscando
        }
    }

    // Si no se encontr� la invitaci�n, devolver -1
    if (pos == -1) 
    {
        printf("No se encontr� la invitaci�n con id %s\n", id);
        return -1;
    }

    // Copiar la lista de jugadores de la invitaci�n encontrada
    char jugadores[2000];
    strcpy(jugadores, lista->listaInvitaciones[pos].jugadores);

    // Contar el n�mero de jugadores
    *nJugadores = 0;
    char *p = strtok(jugadores, "-");
    while (p != NULL) 
    {
        (*nJugadores)++;
        p = strtok(NULL, "-");
    }

    return 0; // Retorno 0 para indicar �xito
}




//-----------------------------------------------------------------------------------------------------------------------//
//-------------------------------------------------- PROGRAMA -----------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------------//

void *AtenderCliente(void *socket) 
{	
	strcpy(ubicacion, "localhost");
	//strcpy(ubicacion, "shiva2.upc.es");
	
	char nomUsuario[20];
	char contra[20];
	char correo[50];
	int ret;
	char buff[512];
	char peticion[512];
	char res[512];
    int sock_conn = *((int *)socket);
    printf("Socket del cliente: %d\n", sock_conn);

	//Inicio el MYSQL
	MYSQL *conn;
	int err;
	// Estructura necessaria para acesso excluyente
	pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
	
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
	}
	
    // Conectar con el servidor MySQL
    if (mysql_real_connect(conn, ubicacion, "root", "mysql", "M4_BBDDParchis", 0, NULL, 0) == NULL) 
	{
        printf("Error al conectar con el servidor MySQL\n");
        mysql_close(conn);
        close(sock_conn);
        pthread_exit(NULL);
    }

	int terminar = 0;
    while (terminar ==0) 
	{
        ret = read(sock_conn, buff, sizeof(buff));	
		buff[ret]='\0';				
		printf ("------------------------------------------\nPeticion recibida: %s\n",buff);

        // Procesar las peticiones del cliente segun el codigo recibido
        char *p = strtok(buff, "/");
		if (p == NULL) {
			printf("Error: Codigo no especificado.\n");
			break;
		}
        int codigo = atoi(p);

		if(codigo == -2){ //Darse de baja
			
			p = strtok(NULL, "/");
			if (p == NULL) {
				printf("Error: Correo no especificado.\n");
				break;
			}
			strcpy(correo, p);
			
			p = strtok(NULL, "/");
			if (p == NULL) {
				printf("Error: Usuario no especificado.\n");
				break;
			}
			strcpy(nomUsuario, p);
			
			p = strtok(NULL, "/");
			if (p == NULL) {
				printf("Error: Contrase�a no especificada.\n");
				break;
			}
			strcpy(contra, p);			
			
			int estaConectado = EstaConectado(&listaConect, nomUsuario);
			if(estaConectado==-1){
				char consulta[1000];
				strcpy(consulta, "SELECT * FROM Usuario WHERE Nombre_Usuario = '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "' AND Passwd = '");
				strcat(consulta, contra);
				strcat(consulta, "' AND Correo = '");
				strcat(consulta, correo);
				strcat(consulta, "';");
				
				int err = mysql_query(conn, consulta);
				if (err != 0) 
				{
					printf("Error al consultar datos de la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
					close(sock_conn);
					pthread_exit(NULL);
				}
				
				resultado = mysql_store_result(conn);
				int n_rows = mysql_num_rows(resultado);
				
				if (n_rows > 0) 
				{
					// Insertar el usuario en la base de datos
					char consulta2[1000];
					strcpy(consulta2, "DELETE FROM Usuario WHERE Nombre_Usuario = '");
					strcat(consulta2, nomUsuario);
					strcat(consulta2, "';");
					
					err = mysql_query(conn, consulta2);
					if (err != 0) 
					{
						printf("Error al insertar datos en la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
						close(sock_conn);
						pthread_exit(NULL);
					}
					
					printf("Usuario dado de baja con exito!\n");
					strcpy(buff, "-2/1");			
					
					int bytes_enviados = write(sock_conn, buff, strlen(buff));
					if (bytes_enviados <= 0) 
					{
						printf("Error al enviar datos al cliente\n");
					}
				}
				else{
					printf("Este usuario no existe!\n");
					strcpy(buff, "-2/-1");			
					
					int bytes_enviados = write(sock_conn, buff, strlen(buff));
					if (bytes_enviados <= 0) 
					{
						printf("Error al enviar datos al cliente\n");
					}
				}
			}
			else{
				printf("Este usuario esta conectado\n");
				strcpy(buff, "-2/-2");			
				
				int bytes_enviados = write(sock_conn, buff, strlen(buff));
				if (bytes_enviados <= 0) 
				{
					printf("Error al enviar datos al cliente\n");
				}
			}
			
		}
		if (codigo == -1) // Desconexion
		{
			close(sock_conn);
			terminar = 1;
		}
		
        else if (codigo == 0) // Desconexion del cliente
		{ 
            p = strtok(NULL, "/");
			if (p == NULL) {
				printf("Error: Usuario no especificado.\n");
				break;
			}
            strcpy(nomUsuario, p);
			
            int eliminar = EliminarConectado(&listaConect, nomUsuario);
			
			// Enviar lista de usuarios conectados a todos los clientes
			EnviarConectados(peticion);		
			
			for (int i = 0; i < listaConect.num; i++) 
			{
				int bytes_enviados = write(listaConect.listaConectado[i].socket, peticion, strlen(peticion));
				if (bytes_enviados <= 0) 
				{
					printf("Error al enviar datos al cliente\n");
				}
			}		
			printf("Lista de conectados actualizada enviada a todos los usuarios conectados!\n");
            close(sock_conn);
			terminar = 1;
        }
        
		else if (codigo == 1) 
		{			
			p = strtok(NULL, "/");
			if (p == NULL) {
				printf("Error: Correo no especificado.\n");
				break;
			}
			strcpy(correo, p);

			p = strtok(NULL, "/");
			if (p == NULL) {
				printf("Error: Usuario no especificado.\n");
				break;
			}
			strcpy(nomUsuario, p);

			p = strtok(NULL, "/");
			if (p == NULL) {
				printf("Error: Contrase�a no especificada.\n");
				break;
			}
			strcpy(contra, p);			
			
			char consulta1[1000];
			strcpy(consulta1, "SELECT * FROM Usuario WHERE Nombre_Usuario = '");
			strcat(consulta1, nomUsuario);
			strcat(consulta1, "';");

			int err = mysql_query(conn, consulta1);
			if (err != 0) 
			{
				printf("Error al consultar datos de la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
				close(sock_conn);
				pthread_exit(NULL);
			}

			resultado = mysql_store_result(conn);
			int n_rows = mysql_num_rows(resultado);

			if (n_rows == 0) 
			{
				// Insertar el usuario en la base de datos
				char consulta2[1000];
				strcpy(consulta2, "INSERT INTO Usuario (Nombre_Usuario, Correo, Passwd, Victorias) VALUES ('");
				strcat(consulta2, nomUsuario);
				strcat(consulta2, "', '");
				strcat(consulta2, correo);
				strcat(consulta2, "', '");
				strcat(consulta2, contra);
				strcat(consulta2, "', '0');");

				err = mysql_query(conn, consulta2);
				if (err != 0) 
				{
					printf("Error al insertar datos en la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
					close(sock_conn);
					pthread_exit(NULL);
				}

				printf("Usuario registrado con exito!\n");
				strcpy(buff, "1/1");			
				
				int add = AnadirConectado(&listaConect, nomUsuario, sock_conn);
				int bytes_enviados = write(sock_conn, buff, strlen(buff));
				if (bytes_enviados <= 0) 
				{
					printf("Error al enviar datos al cliente\n");
				}
				
				
				if (add != 0) 
				{
					printf("Error al agregar el usuario a la lista de conectados\n");
					close(sock_conn);
					pthread_exit(NULL);
				}
							
				// Enviar lista de usuarios conectados a todos los clientes
				EnviarConectados(peticion);
				
				for (int i = 0; i < listaConect.num; i++) 
				{
					int bytes_enviados = write(listaConect.listaConectado[i].socket, peticion, strlen(peticion));
					if (bytes_enviados <= 0) 
					{
						printf("Error al enviar datos al cliente\n");
					}
				}
				printf("Lista de conectados actualizada enviada a todos los usuarios conectados!\n");
			} 
			else 
			{
				strcpy(buff, "1/-1");
				printf("El usuario ya existe!\n");
				int bytes_enviados = write(sock_conn, buff, strlen(buff));
				if (bytes_enviados <= 0) 
				{
					printf("Error al enviar datos al cliente\n");
				}
			}			
		}
		
		//El usuario inicia sesion y se a�ade a la lista de conectados
		else if (codigo == 2) 
		{
			p = strtok(NULL, "/");
			if (p == NULL) {
				printf("Error: Usuario no especificado.\n");
				break;
			}
			strcpy(nomUsuario, p);

			p = strtok(NULL, "/");
			if (p == NULL) {
				printf("Error: Contrase�a no especificada.\n");
				break;
			}
			strcpy(contra, p);
			
			char consulta[1000];
			strcpy(consulta, "SELECT Nombre_Usuario FROM Usuario WHERE Nombre_Usuario = '");
			strcat(consulta, nomUsuario);
			strcat(consulta, "' AND Passwd = '");
			strcat(consulta, contra);
			strcat(consulta, "';");

			err = mysql_query(conn, consulta);
			if (err != 0) 
			{
				printf("Error al consultar datos de la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
				close(sock_conn);
				pthread_exit(NULL);
			}

			resultado = mysql_store_result(conn);
			row = mysql_fetch_row(resultado);

			if (row == NULL) 
			{
				strcpy(buff, "2/-1");
				printf("El usuario no existe o las credenciales son incorrectas\n");
				int bytes_enviados = write(sock_conn, buff, strlen(buff));
				if (bytes_enviados <= 0) 
				{
					printf("Error al enviar datos al cliente\n");
				}
			} 
			else 
			{
				int estaConectado = EstaConectado(&listaConect, nomUsuario);
				
				if (estaConectado == 0) {
					strcpy(buff, "2/-2");
					printf("Este usuario ya est� conectado.\n");
					int bytes_enviados = write(sock_conn, buff, strlen(buff));
					if (bytes_enviados <= 0) 
					{
						printf("Error al enviar datos al cliente\n");
					}
				} 
				else 
				{
					strcpy(buff, "2/1");
					printf("Usuario autenticado con exito\n");
					
					int add = AnadirConectado(&listaConect, nomUsuario, sock_conn);	
					int bytes_enviados = write(sock_conn, buff, strlen(buff));
					if (bytes_enviados <= 0) 
					{
						printf("Error al enviar datos al cliente\n");
					}
					
					// Enviar lista de usuarios conectados a todos los clientes
					EnviarConectados(peticion);
					
					for (int i = 0; i < listaConect.num; i++) 
					{
						int bytes_enviados = write(listaConect.listaConectado[i].socket, peticion, strlen(peticion));
						if (bytes_enviados <= 0) 
						{
							printf("Error al enviar datos al cliente\n");
						}
					}
					printf("Lista de conectados actualizada enviada a todos los usuarios conectados!\n");
				}
			}
		}
		
		else if(codigo == 3) // Crear sala: 3/Admin sala
		{
			p = strtok(NULL, "/");
			if (p == NULL) {
				printf("Error: Usuario no especificado.\n");
				break;
			}
			strcpy(nomUsuario, p);				
					
			char notificacion[20];
			int crear = CrearSala(&listaInvita, &listaConect, nomUsuario);
			if(crear == 1) sprintf(notificacion, "3/1");
			else strcpy(notificacion, "3/-1");
								
			int bytes_enviados = write(sock_conn, notificacion, strlen(notificacion));
			if (bytes_enviados <= 0) 
			{
				printf("Error al enviar datos al cliente\n");
			}		
			
			if(crear == 1)
			{
				char jugadores[2000];
				char listaJugadores[2000];
				VerSala(&listaInvita, nomUsuario, jugadores);
				sprintf(listaJugadores, "5/%s",jugadores);				
				printf("Envio lista de jugadores: '%s' por el socket: '%d'\n", listaJugadores, sock_conn);
				int bytes_enviados = write(sock_conn, listaJugadores, strlen(listaJugadores));
				if (bytes_enviados <= 0) 
				{
					printf("Error al enviar datos al cliente\n");
				}
			}			
		}
		
		else if (codigo == 4) // Abandonar o eliminar sala: 4/Usuario/Nombre sala
		{
			char notificacion[200];
			char notificacion2[200];
			char jugadores[2000];
			char listaJugadores[2000];

			p = strtok(NULL, "/");
			if (p == NULL) {
				printf("Error: Usuario no especificado.\n");
				break;
			}
			strcpy(nomUsuario, p);

			int esAdmin = EsAdmin(&listaInvita, nomUsuario);
			if (esAdmin == 1) 
			{
				strcpy(notificacion2, "10/La sala ha sido eliminada.");
				VerSala(&listaInvita, nomUsuario, jugadores);
				strcpy(listaJugadores, jugadores);
				char Sockets_Jugadores_Sala[400];
				int n = Dame_Sockets_Sala(&listaInvita, &listaConect, nomUsuario, Sockets_Jugadores_Sala, jugadores);

				if (n > 0) 
				{
					char *l = strtok(Sockets_Jugadores_Sala, "-");
					for (int i = 0; i < n; i++) 
					{
						if (l == NULL) break; // Verificar que l no sea NULL
						int socket_actual = atoi(l);
						printf("Envio notificaci�n de sala eliminada por el socket: '%d'\n", socket_actual);
						int bytes_enviados = write(socket_actual, notificacion2, strlen(notificacion2));
						if (bytes_enviados <= 0) {
							printf("Error al enviar datos al cliente\n");
						}
						l = strtok(NULL, "-");
					}
				}

				int eliminar = EliminarSala(&listaInvita, &listaConect, nomUsuario);
				if (eliminar == 1) strcpy(notificacion, "4/1");
				else strcpy(notificacion, "4/-1");

				int bytes_enviados = write(sock_conn, notificacion, strlen(notificacion));
				if (bytes_enviados <= 0) {
					printf("Error al enviar datos al cliente\n");
				}
			}
			else
			{
				int estaEnUnaSala = EstaEnUnaSala(&listaConect, nomUsuario);
				if (estaEnUnaSala == 1)
				{
					char nombreSala[200];
					p = strtok(NULL, "/");
					if (p == NULL) {
						printf("Error: Nombre de sala no especificado.\n");
						strcpy(notificacion, "4/-1");
						int bytes_enviados = write(sock_conn, notificacion, strlen(notificacion));
						if (bytes_enviados <= 0) {
							printf("Error al enviar datos al cliente\n");
						}
					}
					strcpy(nombreSala, p);

					int abandonar = AbandonarSala(&listaInvita, &listaConect, nomUsuario, nombreSala);
					if (abandonar == 1) 
					{
						strcpy(notificacion, "4/1");
						int bytes_enviados = write(sock_conn, notificacion, strlen(notificacion));
						if (bytes_enviados <= 0) {
							printf("Error al enviar datos al cliente\n");
						}

						char jugadores[2000];
						char jugadores2[2000];
						char notificacion_jugadores[2000];
						VerSala(&listaInvita, nombreSala, jugadores);
						strcpy(jugadores2, jugadores);
						char Sockets_Jugadores_Sala[400];
						int n = Dame_Sockets_Sala(&listaInvita, &listaConect, nombreSala, Sockets_Jugadores_Sala, jugadores2);
						sprintf(notificacion_jugadores, "5/%s", jugadores);

						printf("Sockets sala: %s\n", Sockets_Jugadores_Sala);
						printf("Jugadores sala: %s\n", jugadores);

						char *l = strtok(Sockets_Jugadores_Sala, "-");
						for (int i = 0; i < n; i++) {
							if (l == NULL) break;
							int socket_actual = atoi(l);
							printf("Envio notificaci�n lista de jugadores: '%s' por el socket: '%d'\n", notificacion_jugadores, socket_actual);
							int bytes_enviados_jugadores = write(socket_actual, notificacion_jugadores, strlen(notificacion_jugadores));
							if (bytes_enviados_jugadores <= 0) {
								printf("Error al enviar datos al cliente\n");
							}
							l = strtok(NULL, "-");
						}
						printf("Lista de jugadores actualizada enviada a todos los usuarios de la sala!\n");
					}
					else {
						strcpy(notificacion, "4/-1");
						int bytes_enviados = write(sock_conn, notificacion, strlen(notificacion));
						if (bytes_enviados <= 0) {
							printf("Error al enviar datos al cliente\n");
						}
					}
				}
				else
				{
					strcpy(notificacion, "4/-1");
					printf("El usuario '%s' no esta en ninguna sala.\n", nomUsuario);
					int bytes_enviados = write(sock_conn, notificacion, strlen(notificacion));
					if (bytes_enviados <= 0) {
						printf("Error al enviar datos al cliente\n");
					}
				}
			}
		}
		
		else if(codigo == 7) // Invitacion: 7/Persona que invita/Persona invitada
		{
			char invitador[200];
			p = strtok(NULL, "/");
			strcpy(invitador, p);
			
			char invitado[50];            
			p = strtok(NULL, "/");
			strcpy(invitado, p);    
			
			int salaLlena = SalaLlena(&listaInvita, invitador);
			if(salaLlena == 0){
				int enSala = EstaEnUnaSala(&listaConect, invitado);
				if (enSala == 0) {
					char mensaje[200];    
					printf("'%s' ha invitado a jugar a '%s'.\n", invitador, invitado);    
					strcpy(mensaje, "Solicitud enviada.");
					snprintf(buff, sizeof(buff), "7/%s", mensaje);
					
					int bytes_enviados = write(sock_conn, buff, strlen(buff));
					if (bytes_enviados <= 0) {
						printf("Error al enviar datos al cliente\n");
					}
					
					char invitacion[200];
					snprintf(invitacion, sizeof(invitacion), "8/%s/%s", invitador, invitado);
					int sock_invitado = Dame_Socket(&listaConect, invitado);
					bytes_enviados = write(sock_invitado, invitacion, strlen(invitacion));
					if (bytes_enviados <= 0) {
						printf("Error al enviar datos al cliente\n");
					}
					printf("Se ha enviado la invitacion al usuario '%s' por el socket '%d'.\n", invitado, sock_invitado);             
				}
				else {
					char notificacion[200];
					snprintf(notificacion, sizeof(notificacion), "7/Invitacion invalida. '%s' ya esta en una sala.", invitado);
					int bytes_enviados = write(sock_conn, notificacion, strlen(notificacion));
					if (bytes_enviados <= 0) {
						printf("Error al enviar datos al cliente\n");
					}
					printf("No se ha podido invitar a '%s' porque ya est� en una sala.\n", invitado);
				}
			}
			else{
				char notif[200];
				strcpy(notif, "7/La sala esta llena.");           
				int bytes_enviados = write(sock_conn, notif, strlen(notif));
				if (bytes_enviados <= 0) {
					printf("Error al enviar datos al cliente\n");
				}
				printf("No se puede invitar, la sala esta llena.\n");
			}
		}
		
		else if (codigo == 8) // Aceptar o rechazar invitacion: 8/Persona que invita/Persona invitada/(1 o -1)
		{
			char invitador[200];
			p = strtok(NULL, "/");
			strcpy(invitador, p);
			
			char invitado[200];            
			p = strtok(NULL, "/");
			strcpy(invitado, p);
			
			int aceptada;
			int anadir;
			p = strtok(NULL, "/");
			aceptada = atoi(p);
			char notificacion[200];
			char notificacion2[200];
			char notificacion3[200];
			
			if (aceptada == 1) {
				anadir = AnadirASala(&listaInvita, &listaConect, invitador, invitado);    
				
				if (anadir == 1) {                            
					char jugadores[2000];
					char jugadores2[2000];            
					VerSala(&listaInvita, invitador, jugadores);
					strcpy(jugadores2, jugadores);
					char Sockets_Jugadores_Sala[400];
					int n = Dame_Sockets_Sala(&listaInvita, &listaConect, invitador, Sockets_Jugadores_Sala, jugadores2);                 
					sprintf(notificacion3, "5/%s", jugadores); 
					printf("Sockets sala: %s\n", Sockets_Jugadores_Sala);
					printf("Jugadores sala: %s\n", jugadores);
					char *l = strtok(Sockets_Jugadores_Sala, "-");
					for (int i = 0; i < n; i++) {    
						if (l == NULL) break;
						int socket_actual = atoi(l);
						printf("Envio notificacion lista de jugadores: '%s' por el socket: '%d'\n", notificacion3, socket_actual);
						int bytes_enviados = write(socket_actual, notificacion3, strlen(notificacion3));
						if (bytes_enviados <= 0) {
							printf("Error al enviar datos al cliente\n");
						}
						l = strtok(NULL, "-");
					}
					printf("Lista de jugadores actualizada enviada a todos los usuarios de la sala!\n");
					
					sprintf(notificacion, "9/'%s' se ha unido a la sala.", invitado);
					printf("'%s' se ha unido a la sala.\n", invitado);
					
					// Notificación para todos los usuarios de la sala
					l = strtok(Sockets_Jugadores_Sala, "-");
					for (int i = 0; i < n; i++) {
						if (l == NULL) break;
						int socket_actual = atoi(l);
						int bytes_enviados = write(socket_actual, notificacion, strlen(notificacion));
						if (bytes_enviados <= 0) {
							printf("Error al enviar datos al cliente\n");
						}
						l = strtok(NULL, "-");
					}
					
					// Notificación específica para el invitado
					int sock_invitado = Dame_Socket(&listaConect, invitado);
					strcpy(notificacion2, "9/Te has unido a la sala.");
					int bytes_enviados = write(sock_invitado, notificacion2, strlen(notificacion2));
					if (bytes_enviados <= 0) {
						printf("Error al enviar datos al cliente\n");
					} 
				}
				else {
					strcpy(notificacion, "La sala esta llena, intentalo mas tarde.\n");                
					int sock_invitado = Dame_Socket(&listaConect, invitado);
					int bytes_enviados = write(sock_invitado, notificacion, strlen(notificacion));
					if (bytes_enviados <= 0) {
						printf("Error al enviar datos al cliente\n");
					}
				}
			}
			else {
				printf("'%s' ha rechazado la invitacion de union a la sala.\n", invitado);
				sprintf(notificacion, "9/'%s' ha rechazado la solicitud de union a la sala.", invitado);
				int sock_invitador = Dame_Socket(&listaConect, invitador);
				int bytes_enviados = write(sock_invitador, notificacion, strlen(notificacion));
				if (bytes_enviados <= 0) {
					printf("Error al enviar datos al cliente\n");
				}  
			}            
		}

		else if(codigo == 13) //
		{
			p = strtok(NULL, "/");
			if (p == NULL) {
				printf("Error: Consulta no especificada.\n");
				break;
			}
			int nConsulta = atoi(p);
			
			p = strtok(NULL, "/");
			if (p == NULL) {
				printf("Error: Usuario no especificado.\n");
				break;
			}
			strcpy(nomUsuario, p);				
			
			if (nConsulta == 1) 
			{ 
				char consulta[2000];
				strcpy(consulta, "SELECT DISTINCT Jugador FROM ("
					"SELECT Jugador1 AS Jugador FROM Partida WHERE Jugador1 != '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "' AND (Jugador2 = '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "' OR Jugador3 = '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "' OR Jugador4 = '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "') "
					"UNION "
					"SELECT Jugador2 AS Jugador FROM Partida WHERE Jugador2 != '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "' AND (Jugador1 = '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "' OR Jugador3 = '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "' OR Jugador4 = '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "') "
					"UNION "
					"SELECT Jugador3 AS Jugador FROM Partida WHERE Jugador3 != '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "' AND (Jugador1 = '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "' OR Jugador2 = '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "' OR Jugador4 = '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "') "
					"UNION "
					"SELECT Jugador4 AS Jugador FROM Partida WHERE Jugador4 != '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "' AND (Jugador1 = '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "' OR Jugador2 = '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "' OR Jugador3 = '");
				strcat(consulta, nomUsuario);
				strcat(consulta, "')) AS TodosLosJugadores;");

				int err = mysql_query(conn, consulta);
				if (err != 0) 
				{
					printf("Error al consultar datos de la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
					close(sock_conn);
					pthread_exit(NULL);
				}
				
				resultado = mysql_store_result(conn);
				int n_rows = mysql_num_rows(resultado);
				char jugadores[2000];
				char mensaje[2000];
				if (n_rows > 0) 
				{
					while ((row = mysql_fetch_row(resultado))) 
					{
						sprintf(jugadores, "%s%s-", jugadores, row[0]);
						
					}
					sprintf(mensaje, "13/1/1/%s", jugadores);
					printf("Enviando mensaje: %s por el socket: '%d'\n", mensaje, sock_conn);
					int bytes_enviados = write(sock_conn, mensaje, strlen(mensaje));
					if (bytes_enviados <= 0) 
					{
						printf("Error al enviar datos al cliente\n");
					}
				}
				else
				{
					printf("'%s' no ha jugado con nadie todav�a.\n", nomUsuario);
					strcpy(buff, "13/1/-1");            
					
					int bytes_enviados = write(sock_conn, buff, strlen(buff));
					if (bytes_enviados <= 0) 
					{
						printf("Error al enviar datos al cliente\n");
					}
				}   
				strcpy(jugadores, "");
			}

			else if(nConsulta == 2){ // Resultados de las partidas que jug� con uno o m�s jugadores determinados.

				char jugadores[1000];
				p = strtok(NULL, "/");
				if (p == NULL) {
					printf("Error: Nombres de los jugadores no especificados.\n");
					break;
				}
				strcpy(jugadores, p);

				// Separar los nombres de los jugadores
				char *jugador;
				char condicion[4000] = "";
				jugador = strtok(jugadores, ",");
				while (jugador != NULL) {
					if (strlen(condicion) > 0) {
						strcat(condicion, " AND");
					}
					strcat(condicion, "(Jugador1 = '");
					strcat(condicion, jugador);
					strcat(condicion, "' OR Jugador2 = '");
					strcat(condicion, jugador);
					strcat(condicion, "' OR Jugador3 = '");
					strcat(condicion, jugador);
					strcat(condicion, "' OR Jugador4 = '");
					strcat(condicion, jugador);
					strcat(condicion, "')");
					jugador = strtok(NULL, ",");
				}

				char consulta2[5000];
				sprintf(consulta2, "SELECT * FROM Partida WHERE (Jugador1 = '%s' OR Jugador2 = '%s' OR Jugador3 = '%s' OR Jugador4 = '%s') AND (%s);",
						nomUsuario, nomUsuario, nomUsuario, nomUsuario, condicion);
				int err = mysql_query(conn, consulta2);
				if (err != 0) {
					printf("Error al consultar datos de la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
					close(sock_conn);
					pthread_exit(NULL);
				}

				resultado = mysql_store_result(conn);
				int n_rows = mysql_num_rows(resultado);
				char mensaje[10000] = "";
				char partida[10000] = "";

				if (n_rows > 0) {
					row = mysql_fetch_row(resultado);
					sprintf(partida, "%s|%s|%s|%s|%s|%s", row[1], row[2], row[3], row[4], row[5], row[6]);
					while ((row = mysql_fetch_row(resultado))) {
						sprintf(partida, "%s*%s|%s|%s|%s|%s|%s", partida, row[1], row[2], row[3], row[4], row[5], row[6]);
					}
					sprintf(mensaje, "13/2/1/%s", partida);
					printf("Enviando mensaje: %s por el socket: '%d'\n", mensaje, sock_conn);
					int bytes_enviados = write(sock_conn, mensaje, strlen(mensaje));
					if (bytes_enviados <= 0) {
						printf("Error al enviar datos al cliente\n");
					}

				} else {
					printf("No se encontraron partidas con los jugadores especificados.\n");
					strcpy(buff, "13/2/-1");
					int bytes_enviados = write(sock_conn, buff, strlen(buff));
					if (bytes_enviados <= 0) {
						printf("Error al enviar datos al cliente\n");
					}
				}
				mysql_free_result(resultado);
			}


			else if(nConsulta == 3){ //Lista de partidas jugadas en un periodo de tiempo dado.
			
				char fechaInicio[200];
				char fechaFin[200];
				
				p = strtok(NULL, "|");
				if (p == NULL) {
					printf("Error: Fecha inicial no especificada.\n");					
					break;
				}
				strcpy(fechaInicio, p);
				
				p = strtok(NULL, "|");
				if (p == NULL) {
					printf("Error: Fecha final no especificada.\n");;
					break;
				}
				strcpy(fechaFin, p);
				
				char consulta2[2000];
				sprintf(consulta2, "SELECT * FROM Partida WHERE fecha BETWEEN '%s' AND '%s' AND (Jugador1 = '%s' OR Jugador2 = '%s' OR Jugador3 = '%s' OR Jugador4 = '%s');", fechaInicio, fechaFin, nomUsuario, nomUsuario, nomUsuario, nomUsuario);
				int err = mysql_query(conn, consulta2);
				if (err != 0) 
				{
					printf("Error al consultar datos de la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
					close(sock_conn);
					pthread_exit(NULL);
				}
				
				resultado = mysql_store_result(conn);
				int n_rows = mysql_num_rows(resultado);
				char mensaje[10000] = "";
				char partida[10000] = "";
				
				if (n_rows > 0) {
					row = mysql_fetch_row(resultado);
					sprintf(partida, "%s|%s|%s|%s|%s|%s", row[1], row[2], row[3], row[4], row[5], row[6]);
					while ((row = mysql_fetch_row(resultado))) {
						sprintf(partida, "%s*%s|%s|%s|%s|%s|%s",partida, row[1], row[2], row[3], row[4], row[5], row[6]);						
					}	
					sprintf(mensaje, "13/3/1/%s", partida);
					printf("Enviando mensaje: %s por el socket: '%d'\n", mensaje, sock_conn);
					int bytes_enviados = write(sock_conn, mensaje, strlen(mensaje));
					if (bytes_enviados <= 0) {
						printf("Error al enviar datos al cliente\n");
					}
					
				} else {
					printf("No se encontraron partidas en el per�odo especificado.\n");
					strcpy(buff, "13/3/-1");
					int bytes_enviados = write(sock_conn, buff, strlen(buff));
					if (bytes_enviados <= 0) {
						printf("Error al enviar datos al cliente\n");
					}
				}
				mysql_free_result(resultado);
			}
		}		
		else{
			printf("Codigo no valido.\n");
		}
	}	

    // Cerrar la conexion MySQL y el socket
    mysql_close(conn);
    close(sock_conn);
    pthread_exit(NULL);
}

//-----------------------------------------------------------------------------------------------------------------------//
//---------------------------------------------------- MAIN -------------------------------------------------------------//
//-----------------------------------------------------------------------------------------------------------------------//

int main(int argc, char *argv[]) {
    strcpy(ubicacion, "localhost");
    //strcpy(ubicacion, "shiva2.upc.es");
    //Inicio el MYSQL
    MYSQL *conn;
    int err;
    // Estructura necessaria para acesso excluyente
    pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

    // Estructura especial para almacenar resultados de consultas 
    MYSQL_RES *resultado;
    MYSQL_ROW row;
    //Creamos una conexion al servidor MYSQL 
    conn = mysql_init(NULL);
    if (conn == NULL) {
        printf("Error al crear la conexion: %u %s\n",
            mysql_errno(conn), mysql_error(conn));
        exit(1);
    }
    //Inicializar la conexion
    conn = mysql_real_connect(conn, ubicacion, "root", "mysql", "M4_BBDDParchis", 0, NULL, 0);
    if (conn == NULL) {
        printf("Error al inicializar la conexion: %u %s\n",
            mysql_errno(conn), mysql_error(conn));
        exit(1);
    }

    int sock_conn, sock_listen, ret;
    struct sockaddr_in serv_adr;
    // INICIALITZACIONS
    // Obrim el socket
    if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
        printf("Error creando el socket\n");
    // Fem el bind al port
    memset(&serv_adr, 0, sizeof(serv_adr)); // inicialitza a zero serv_addr
    serv_adr.sin_family = AF_INET;
    // asocia el socket a cualquiera de las IP de la máquina. 
    // htonl formatea el numero que recibe al formato necesario
    serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
    //50016
    serv_adr.sin_port = htons(9070);

    if (bind(sock_listen, (struct sockaddr *)&serv_adr, sizeof(serv_adr)) < 0)
        printf("Error al bind\n");
    //La cola de peticiones pendientes no podrá ser superior a 4
    if (listen(sock_listen, 2) < 0)
        printf("Error en el Listen\n");

    InicializarListas();

    int terminar = 0;

    pthread_t thread;

    while (terminar == 0) {
        printf("Escuchando\n");	

        sock_conn = accept(sock_listen, NULL, NULL);
        printf("He recibido conexion\n");
        //sock_conn es el socket que usaremos para este cliente

        sockets[i] = sock_conn;
        Conectado nuevaConex;

        //Crear hilo y decirle lo que tiene que hacer
        pthread_create(&thread, NULL, AtenderCliente, &sockets[i]);
        i++;
    }

    // Cerrar la conexion MySQL
    mysql_close(conn);

    return 0;
}
