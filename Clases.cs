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
    public class LoginRequest
    {
        [JsonPropertyName("Username")]
        public string username { get; set; }

        [JsonPropertyName("PasswordHash")]
        public string password { get; set; }

        [JsonPropertyName("ServiceId")]
        public int ServiceId { get; set; }

        public LoginRequest(string usr, string pw) {
            username = usr;
            password = Utils.sha256_hash(pw);
            ServiceId = 1;
        }
 
    }

    public class UserSession
    {
        // The user ID
        [JsonPropertyName("UserId")]
        public int UserId { get; set; }

        // The session token for the user.
        [JsonPropertyName("SessionToken")]
        public string SessionToken { get; set; }
    }

    class ClientSession : UserSession
    {
        [JsonPropertyName("ClientId")]
        public int ClientId { get; set; }
    }

    public class BankUser
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Username")]
        public string Username { get; set; }
        [JsonPropertyName("Password")]
        public string Password { get; set; }
        [JsonPropertyName("LastLoginTime")]
        public DateTime LastLoginTime { get; set; }
    }

    public class BankClient
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("User")]
        public BankUser User { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Cedula")]
        public string Cedula { get; set; }
        [JsonPropertyName("Sex")]
        public int Sex { get; set; }
        [JsonPropertyName("RegisterDate")]
        public DateTime RegisterDate { get; set; }
    }

    public class ClientInfoRequest
    {

        [JsonPropertyName("SessionToken")]
        public string SessionToken { get; set; }
        [JsonPropertyName("ClientId")]
        public int ClientId { get; set; }

        public ClientInfoRequest(string sesTok, int clId) 
        {
            SessionToken = sesTok;
            ClientId = clId;
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
}