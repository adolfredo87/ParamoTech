using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Utilitys
{
	public class StreamFile
	{
        public readonly static string path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
        public readonly static string pathJson = @"F:\Proyectos\Git\adolfredo87\ParamoTech\Sat.Recruitment.Api\Files\Users.json";

        private static StreamReader ReadFromFile()
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }

        public List<User> RecorreUserFile()
        {
            List<User> _users = new List<User>();
            var reader = ReadFromFile();
            _users = User.LeerDatosArchivo(reader);

            return _users;
        }

        public void CargarDatosJson(List<User> _users)
		{
            string json = JsonConvert.SerializeObject(_users);
            this.CrearArchivoJson(json);
        }

        public void CrearArchivoJson(string json) 
        {
            this.CrearArchivo(pathJson);
            this.EscribirLinea(json, pathJson);
        }

        private void EscribirLinea(string valor, string path)
        {
            StreamWriter objEscritor = default(StreamWriter);
            objEscritor = File.AppendText(path);
            objEscritor.WriteLine(valor);
            objEscritor.Close();
        }

        public void CrearArchivo(string path)
        {
            //** Verificar si existe el archivo **
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            else
			{
                FileStream archivo = default(FileStream);
                archivo = File.Create(path);
                archivo.Close();
            }
        }
    }
}
