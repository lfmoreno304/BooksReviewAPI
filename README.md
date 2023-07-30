# Instalación de Proyecto Paso a Paso

## Clonar el Repositorio

1. Abre tu terminal o línea de comandos.
2. Navega al directorio donde deseas clonar el repositorio.
3. Ejecuta el siguiente comando para clonar el repositorio desde GitHub:

```bash
git clone https://github.com/lfmoreno304/BooksReviewAPI.git
```

## Esquema de base de datos
1. Asegúrate de tener instalado el motor de base de datos que se utiliza en el proyecto (MySql)
```sql
CREATE TABLE `books` (
	`book_id` int NOT NULL AUTO_INCREMENT,
	`title` varchar(80) NOT NULL,
	`summary` varchar(800) NOT NULL,
	`category` varchar(15) NOT NULL,
	`img` varchar(200) NOT NULL,
	`author` varchar(100),
	PRIMARY KEY (`book_id`)
)
CREATE TABLE `reviews` (
	`review_id` int NOT NULL AUTO_INCREMENT,
	`description` varchar(200) NOT NULL,
	`rating` int NOT NULL,
	`user_id` int NOT NULL,
	`book_id` int NOT NULL,
	PRIMARY KEY (`review_id`)
)
CREATE TABLE `users` (
	`user_id` int NOT NULL AUTO_INCREMENT,
	`email` varchar(80) NOT NULL,
	`password` varchar(20) NOT NULL,
	`img` varchar(200),
	PRIMARY KEY (`user_id`)
)
```
## Configurar Secretos
1. En el directorio del proyecto, dirigete al proyecto principal de la solucion presionas click derecho y buscas la opcion de `Manejar secretos de usuario`.
2. Esto te llevara a un documento json llamado de la siguiente manera `secrets.json` en este configuraremos las siguientes variables de entorno donde `ConnectionStrings` es la cadena de conexion de la base de datos MySql y `Key` hace referencia a la key para generar el jsonwt.
```json
{
    "ConnectionStrings":"",
    "Key": "",
    "Issuer": "https://localhost:7239/",
    "Audience": "https://localhost:7239/",
    "Subject":  "booksReviewApiSubject"
}
```
## Ejecutar el Proyecto
1. Asegúrate de tener instalado .NET Core SDK en tu máquina.
2. Navega al directorio del proyecto y ejecuta el siguiente comando para restaurar las dependencias:
```bash
dotnet restore
```
3. Compila el proyecto con el siguiente comando:
```bash
dotnet build
```
4. Ejecuta el proyecto con el siguiente comando:
 ```bash
dotnet run
```
