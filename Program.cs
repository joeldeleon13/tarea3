tarea7.motor();


class tarea7
{
    public static void motor()
    {
        List<Motorista> motorista = new List<Motorista>();

        if (System.IO.File.Exists("Motorista.json")){
        var json = System.IO.File.ReadAllText("Motorista.json");
        motorista = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Motorista>>(json) ?? new List<Motorista>();
        }
        
        Console.Clear();
        Console.WriteLine(@"
            
                Hola esta es la  tarea 7!!
                                                    ,-~ |
       ________________          o==]___|
      |                |            \ \
      |________________|            /\ \
 __  /  _,-----._      )           |  \ \.
|_||/_-~         `.   /()          |  /|]_|_____
  |//              \ |              \/ /_-~     ~-_
  //________________||              / //___________\
 //__|______________| \____________/ //___/-\ \~-_
((_________________/_-o___________/_//___/  /\,\  \
 |__/(  ((====)o===--~~                 (  ( (o/)  )
      \  ``==' /                         \  `--'  /
       `-.__,-'       Vespa P-200 E       `-.__,-'


");

        Console.WriteLine(@"

1- Registrar motores  
2- Editar motores 
3- Visualizar en el mapa         
4- Exportar motor 
5- Acerca Del protagonista de este programa                   
6- Salir

");
        Console.Write("Escoga una opcion de las anteriores a la que deseas acceder: ");
        string opcion = Console.ReadLine() ?? "";
        Console.Clear();

        var m = new Motorista();

        switch (opcion)
        {

        case "1": 

        Console.Clear();
        Console.WriteLine("Registrar Motores");

        m.cedula      = Utils.LeerCadena("Ingrese la cedula: ");
        m.nombre      = Utils.LeerCadena("Ingrese el nombre: ");
        m.marca       = Utils.LeerCadena("Ingrese la marca del motor: ");
        m.modelo      = Utils.LeerCadena("Ingrese el modelo del  motor: ");
        m.placa       = Utils.LeerCadena("Ingrese la placa: ");
        m.chasis      = Utils.LeerCadena("Ingrese el chasis: ");
        m.telefono    = Utils.LeerCadena("Ingrese el telefono: ");
        m.direccion   = Utils.LeerCadena("Ingrese la direccion: ");
        m.lat         = Utils.LeerCadena("Ingrese la latitud: ");
        m.lng         = Utils.LeerCadena("Ingrese la longitud: ");
        m.actividad   = Utils.LeerCadena("¿Que actividad ejercia el dueño del motor?: ");
        m.descripcion = Utils.LeerCadena("Describa el motor  ");

        motorista.Add(m);
        Utils.Guardar(motorista);
        Console.WriteLine("Motorista agregado ");
        Utils.retorno();

        break;

        case "2": 

        Console.Clear();
        Console.WriteLine("Editar Motores");
        var cont = 0;

        if(motorista.Count == 0){
            Console.WriteLine("No hay registros de motores");
            tarea7.motor();
        }

        Console.WriteLine("Motores registrados: ");
        foreach (var mot in motorista)
        {
            Console.WriteLine($@"
                Id: {motorista.Count} 
                Cedula: {mot.cedula}
                Nombre: {mot.nombre}
                Marca: {mot.marca}
                Modelo: {mot.modelo}
            ");
            cont++;   
        }

        var pos = Utils.LeerEntero("Ingrese la id del motor a editar: ");
        
        if(pos == 0){
            Console.WriteLine("Posicion inexistente");
            tarea7.motor();
        }

        var moto = motorista[pos-1];
        var valor = "";

        Console.WriteLine($"La cedula actual es: {moto.cedula} digite la nueva cedula o presione ENTER para dejarlo como antes. ");
        valor = Console.ReadLine() ?? "";
        if(valor.Length >0){moto.cedula = valor;}

        Console.WriteLine($"El nombre actual es: {moto.nombre} digite el nuevo nombre o presione ENTER para dejarlo como antes. ");
        valor = Console.ReadLine() ?? "";
        if(valor.Length >0){moto.nombre = valor;} 

        Console.WriteLine($"La marca actual es: {moto.marca} digite la nueva marca o presione ENTER para dejarlo como antes. ");
        valor = Console.ReadLine() ?? "";
        if(valor.Length > 0){moto.marca = valor;}

        Console.WriteLine($"El modelo actual es: {moto.modelo} digite el nuevo modelo o presione ENTER para dejarlo como antes. ");
        valor = Console.ReadLine() ?? "";
        if(valor.Length >0){moto.modelo = valor;}
               

        Console.WriteLine($"La placa actual es: {moto.placa} digite la nueva placa o presione ENTER para dejarlo como antes. ");
        valor = Console.ReadLine() ?? "";
        if(valor.Length >0){moto.placa = valor;}
        
        Console.WriteLine($"El chasis actual es: {moto.chasis} digite el nuevo chasis o presione ENTER para dejarlo como antes. ");
        valor = Console.ReadLine() ?? "";
        if(valor.Length >0){moto.chasis = valor;}
             

        Console.WriteLine($"El telefono actual es: {moto.telefono} digite el nuevo telefono o presione ENTER para dejarlo como antes. ");
        valor = Console.ReadLine() ?? "";
        if(valor.Length >0){moto.telefono = valor;}

        Console.WriteLine($"La direccion actual es: {moto.direccion} digite la nueva direccion o presione ENTER para dejarlo como antes. ");
        valor = Console.ReadLine() ?? "";
        if(valor.Length >0){moto.direccion = valor; }
        
        Console.WriteLine($"La latitud actual es: {moto.lat} digite la nueva latitud o presione ENTER para dejarlo como antes. ");
        valor = Console.ReadLine() ?? "";
        if(valor.Length >0){moto.lat = valor;}
        
        Console.WriteLine($"La longitud actual es: {moto.lng} digite la nueva longitud o presione ENTER para dejarlo como antes. ");
        valor = Console.ReadLine() ?? "";
        if(valor.Length >0){moto.lng = valor; }
               
        Console.WriteLine($"La actividad actual es: {moto.actividad} digite la nueva actividad o presione ENTER para dejarlo como antes. ");
        valor = Console.ReadLine() ?? "";
        if(valor.Length >0){moto.actividad = valor;}
        
        Console.WriteLine($"La descripcion actual es: {moto.descripcion} digite la nueva descripcion o presione ENTER para dejarlo como antes. ");
        valor = Console.ReadLine() ?? "";
        if(valor.Length >0){moto.descripcion = valor;}
              
        Utils.Guardar(motorista);
        Console.WriteLine("Motorista editado correctamente!");
        Utils.retorno();

        break;

        case "3": 
        Console.WriteLine("Mapa");
        var marcador = "";

        foreach (var motor in motorista)
        {
            marcador += @$"

            var marker = L.marker([{motor.lat}, {motor.lng}]).addTo(map)
		     .bindPopup(`
             <h3>{motor.nombre}</h3>
             Marca: {motor.marca}</br>
             Modelo: {motor.modelo}</br>
             Placa: {motor.placa}</br>
             Uso: {motor.actividad}</br>
              `);
            ";
        }

        
        var map = System.IO.File.ReadAllText("plantilla.html");
        map = map.Replace("CODIGODINAMICODEC#", marcador);

        System.IO.File.WriteAllText("mapa.html", map);
        Utils.Nav("mapa.html");
        
        Console.WriteLine("Visualizando Mapa....");
        Utils.retorno();
        
        break;

        case "4": 
        Console.WriteLine("Exportando la licencia!!");
        
        var contx = 0;

         if(motorista.Count == 0){
            Console.WriteLine("No hay registros de motores");
            tarea7.motor();
        }       
        
        Console.WriteLine("Motores registrados: ");
        foreach (var mot in motorista)
        {
            Console.WriteLine($@"
                Id: {motorista.Count} 
                Cedula: {mot.cedula}
                Nombre: {mot.nombre}
                Marca: {mot.marca}
                Modelo: {mot.modelo}
            ");
            contx++;   
        }

        var posx = Utils.LeerEntero("Ingrese la id del motor a editar: ");
        
        if(posx == 0){
            Console.WriteLine("Posicion inexistente");
            tarea7.motor();
        }

        var motos = motorista[posx -1];

        var html = @$"
        
        <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css'>
        <script src='https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js'></script>

        <div class = 'container'>
        <p style='text-align: center;'><strong><img src='https://intrant.gob.do/images/ImagenesPortalPrincipal/logo-ajustado.png' alt='' /></strong></p>
        <p style='text-align: center;'><strong>INTRANT</strong></p>
        <p style='text-align: center;'><strong>LICENCIA DE CONDUCIR</strong></p>
        <p style='text-align: center;'><strong>Datos</strong></p>

        <table style='border-collapse: collapse; width: 100.39%; height: 107px;' border='1'>
        <tbody>
        <tr style='height: 18px;'>
        <td style='width: 50%; height: 18px; text-align: right;'>Nombre</td>
        <td style='width: 50%; height: 18px;'>{motos.nombre}</td>
        </tr>

        <tr style='height: 18px;'>
        <td style='width: 50%; height: 18px; text-align: right;'>Marca</td>
        <td style='width: 50%; height: 18px;'>{motos.marca}</td>
        </tr>
        
        <tr style='height: 18px;'>
        <td style='width: 50%; height: 18px; text-align: right;'>Modelo</td>
        <td style='width: 50%; height: 18px;'>{motos.modelo}</td>
        </tr>

        <tr style='height: 18px;'>
        <td style='width: 50%; height: 18px; text-align: right;'>Cedula</td>
        <td style='width: 50%; height: 18px;'>{motos.cedula}</td>
        </tr>

        </tbody>
        </table>
        </div>
        ";

        System.IO.File.WriteAllText("licencia.html", html);
        Utils.Nav("licencia.html");
        
        Console.WriteLine("Exportando licencia....");
        Utils.retorno();

        break;

        case "5":   Console.WriteLine(@"

 __              .__   
    |__| ____   ____ |  |  
    |  |/  _ \_/ __ \|  |  
    |  (  <_> )  ___/|  |__
/\__|  |\____/ \___  >____/
\______|           \/  
                 Nombre: Joel    
                 Apellido: De Leon Reyes 
                 Telefono: 829-753-2040
                     
        ");

        Console.WriteLine("Presione una tecla para regresar a la tarea7!!");
        Console.ReadKey();
        tarea7.motor();
        break;
        
        case "6": 
        Console.WriteLine("Saliendo del programa Presione una tecla para finalizar");
        Console.ReadKey();
        Environment.Exit(0);
        break;

        default: 
        Console.Write("Opcion Invalida!! Eliga de nuevo");
        Console.ReadKey();
        tarea7.motor();
        break;

        }

    }
}
