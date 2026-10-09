# CaronteWeb

## Descripción
CaronteWeb es una aplicación web basada en ASP.NET MVC y Web API que incluye un sistema de autenticación de usuarios y registro (a través de ASP.NET Identity), gestión de perfiles de usuario y notificaciones (usando ASP.NET WebHooks). Está diseñada para servir como un punto de partida robusto para aplicaciones empresariales que requieren de un backend seguro y una interfaz responsiva.

## Pila Tecnológica (Tech Stack)
A partir del análisis del código y las dependencias, este proyecto utiliza:
- **Framework Principal:** C# y .NET Framework 4.5
- **Arquitectura Web:** ASP.NET MVC 5.2.3 y ASP.NET Web API 5.2.3
- **ORM / Base de Datos:** Entity Framework 6.1.3 y SQL Server LocalDB
- **Autenticación y Seguridad:** ASP.NET Identity 2.2.1 y Microsoft OWIN 3.0.1 (soporte para logins locales y externos como Google, Facebook, Twitter, Microsoft)
- **WebHooks:** Microsoft ASP.NET WebHooks 1.2.2 (Custom y Common)
- **Frontend:** HTML5, CSS3, Bootstrap 3.0.0, jQuery 1.10.2 y Modernizr

## Requisitos Previos
- [Visual Studio 2017 / 2019 / 2022](https://visualstudio.microsoft.com/) con la carga de trabajo de "Desarrollo de ASP.NET y web".
- .NET Framework 4.5 instalado.
- SQL Server Express LocalDB (normalmente incluido con Visual Studio) para la base de datos de desarrollo.

## Instalación y Configuración del Entorno Local

Siga estos pasos para configurar el proyecto en su máquina local:

1. **Clonar el repositorio:**
   ```bash
   git clone <url-del-repositorio>
   cd CaronteWeb
   ```

2. **Abrir el proyecto:**
   - Haga doble clic en el archivo `CaronteWeb.sln` para abrir la solución en Visual Studio.

3. **Restaurar paquetes NuGet:**
   - En Visual Studio, vaya a `Herramientas` > `Administrador de paquetes NuGet` > `Consola del Administrador de paquetes`.
   - Ejecute el siguiente comando para restaurar las dependencias (o simplemente haga clic derecho en la Solución y seleccione "Restaurar paquetes NuGet"):
     ```powershell
     Update-Package -Reinstall
     ```
   - *Nota:* Visual Studio debería restaurar los paquetes automáticamente al compilar, gracias a la funcionalidad de Restauración de Paquetes NuGet.

4. **Configuración de la Base de Datos:**
   - El archivo `CaronteWeb/Web.config` contiene la cadena de conexión `DefaultConnection`. Por defecto, está configurada para usar `(LocalDb)\MSSQLLocalDB` y conectarse/crear un archivo de base de datos `.mdf` dentro de la carpeta `App_Data`.
   - Verifique que la instancia de LocalDB exista, o cambie la cadena de conexión en `Web.config` para apuntar a un servidor SQL de su preferencia.

5. **Compilar el proyecto:**
   - Presione `Ctrl + Shift + B` o vaya a `Compilar` > `Compilar solución`. Alternativamente, usando msbuild en la línea de comandos:
     ```bash
     msbuild CaronteWeb.sln /p:Configuration=Debug
     ```

6. **Ejecutar la aplicación:**
   - Presione `F5` o haga clic en el botón de **Iniciar** (IIS Express) en Visual Studio. El proyecto se abrirá en su navegador predeterminado en `http://localhost:<puerto>/`.

## Estructura Principal de Carpetas

La organización del proyecto sigue el patrón clásico de ASP.NET MVC:

- **`/CaronteWeb/App_Start/`**: Contiene clases de configuración que se ejecutan al iniciar la aplicación (rutas, bundles, filtros, Identity y Web API).
- **`/CaronteWeb/App_Data/`**: Carpeta designada para archivos de datos locales, como la base de datos SQL Server `.mdf` si se usa LocalDB.
- **`/CaronteWeb/Controllers/`**: Contiene los controladores que gestionan la lógica de negocio y las interacciones del usuario (ej. `HomeController`, `AccountController`, `NotifyController`).
- **`/CaronteWeb/Models/`**: Define los modelos de datos, las clases de Entity Framework y los ViewModels usados en las vistas.
- **`/CaronteWeb/Views/`**: Almacena las vistas Razor (`.cshtml`) encargadas de renderizar la interfaz de usuario en el navegador. Organizadas en carpetas por controlador.
- **`/CaronteWeb/Scripts/`**: Archivos JavaScript de terceros (jQuery, Bootstrap) y scripts personalizados.
- **`/CaronteWeb/Content/`**: Archivos CSS (como Bootstrap) y otros recursos estáticos (imágenes).
- **`/CaronteWeb/Global.asax`**: Archivo de punto de entrada global de la aplicación web, el cual inicializa configuraciones principales en el evento `Application_Start`.
- **`/CaronteWeb/Startup.cs`**: Clase de inicio de OWIN donde se configura la autenticación y otros middleware.
- **`/CaronteWeb/Web.config`**: Archivo principal de configuración de la aplicación (cadenas de conexión, opciones de compilación, módulos, etc.).

## Guía de Uso / Ejemplos

Una vez que la aplicación está en ejecución:

1. **Navegación Básica:**
   Puede navegar por la página principal, sección "Acerca de" y "Contacto" mediante el menú de navegación superior.

2. **Registro de Usuarios:**
   - Haga clic en el botón **"Registrarse"** en la esquina superior derecha.
   - Proporcione un correo electrónico y una contraseña para crear una nueva cuenta. Se creará automáticamente la base de datos de Entity Framework gracias al proceso de inicialización (Code First).

3. **Inicio de Sesión:**
   - Acceda mediante **"Iniciar sesión"** usando las credenciales recién creadas.
   - También cuenta con opciones para iniciar sesión mediante proveedores externos (Google, Facebook) que requieren ser configurados previamente en `/CaronteWeb/App_Start/Startup.Auth.cs`.

4. **Notificaciones / WebHooks:**
   - El proyecto incluye un `NotifyController` predeterminado. Puede explorar la ruta correspondiente para verificar el módulo y configurar la integración de ASP.NET WebHooks según su caso de uso.
