class Utils{
    public static void retorno(){
        Console.WriteLine("");
        Console.ReadKey();
        tarea7.motor();
    }
    public static void pausa(){
        Console.WriteLine("");
        Console.ReadKey();
    }

    public static double LeerDoble(string mensaje){
        double numero=0;
        Console.Write(mensaje);
        while(!double.TryParse(Console.ReadLine(), out numero)){
            Console.Write("error, reingrese");
        }
        return numero;
    }

    public static int LeerEntero(string mensaje){
        int numero=0;
        Console.Write(mensaje);
        while(!int.TryParse(Console.ReadLine(), out numero)){
            Console.Write("error, reingrese: ");
        }
        return numero;
    }

    public static string LeerCadena(string mensaje){
        Console.Write(mensaje);
        return Console.ReadLine()??"";
    }

    public static void Nav(string link){
        var psi = new System.Diagnostics.ProcessStartInfo();
        psi.UseShellExecute= true;
        psi.FileName = link;
        System.Diagnostics.Process.Start(psi);
    }
    public static void Guardar(List<Motorista> motorista){
        var archivo = "Motorista.json";
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(motorista);
        File.WriteAllText(archivo, json);
    }

    
}