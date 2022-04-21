using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace InternetBanking
{
    //Login
    public class Usuario
    {



        [JsonPropertyName("Username")]
        public string username { get; set; }

        [JsonPropertyName("PasswordHash")]
        public string password { get; set; }

        [JsonPropertyName("ServiceId")]
        public int ServiceId { get; set; }

        public Usuario(string usr, string pw) {
            username = usr;
            password = Utils.sha256_hash(pw);
            ServiceId = 1;
        }
 
    }

    //Default, cuentas
    public class Cuenta
    { 
        public string Numero { get; set; }
        public float Balance { get; set; }
    }

    //DetalleCuenta
    public class DetalleCuenta
    {
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public float Balance { get; set; }
    }

    public class Movimiento
    { 
        
    }
}