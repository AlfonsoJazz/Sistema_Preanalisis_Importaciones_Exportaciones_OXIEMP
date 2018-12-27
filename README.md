# Sistema_Preanalisis_Importaciones_Exportaciones_OXIEMP

Sistema para el preanalisis de Importaciones y exportaciones -Sistema de inteligencia de negocios OXIEMP

Desarrollado con el uso del Framework .Net 4.0, Visual Studio 2010, Visual Basic .Net y SQL Server 2008.

Este sitio web tiene como objetivo agilizar el proceso de pre análisis de los datos brindados por el SAT para su procesamiento final y posteriormente ser presentados con gráficos en Tableu. Lo cual ayuda a tomar mejores decisiones de compra venta de mercancías y el comportamiento del mercado.

El Acceso es a través del usuario de red del dominio de Windows.
![Login por medio de usuarios del dominio de Windows](/OXIEMP_captures/OXIEMP-Account-Login-aspx.png "Login por medio de Usuarios del dominio de red de Windows")

Con el uso de la librería [SpreadsheetLight for .Net Framework](http://spreadsheetlight.com/) se pueden extraer fragmentos de las tablas disponibles en la base de datos en forma de reportes de excel, todo esto con el uso de filtros y procedimientos almacenados.

![Extraccion de fragmentos de tablas en forma de reportes de excel](/OXIEMP_captures/OXIEMP-Reportes-aspx.png "Página de reportes")

El sitio realiza el pre render inteligentemente validando los datos que faltan por capturar o los que están erróneos, de manera que el usuario solo pueda modificar aquellos que lo necesitan, todo esto llamando procedimientos almacenados. Al momento de capturar, se llenan múltiples tablas de-para a la vez con la finalidad de hacer más inteligente el proceso de corrección en las próximas capturas.
![Pre análisis de Exportaciones](/OXIEMP_captures/OXIEMP-preanalisis_exp-aspx-2.png "Preanálisis exportaciones")
      
