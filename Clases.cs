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
        // Client ID
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

    //GetClient
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

    //GetAccounts
    public class AccountsByClientRequest
    {

        [JsonPropertyName("SessionToken")]
        public string SessionToken { get; set; }
        [JsonPropertyName("ClientId")]
        public int ClientId { get; set; }

        public AccountsByClientRequest(string sesTok, int clId)
        {
            SessionToken = sesTok;
            ClientId = clId;
        }
    }

    //BankAccount
    class BankAccount
    {
        [JsonPropertyName("AccountNumber")]
        public int AccountNumber { get; set; }
        [JsonPropertyName("ClientId")]
        public int ClientId { get; set; }
        [JsonPropertyName("State")]
        public int State { get; set; }
        [JsonPropertyName("Balance")]
        public float Balance { get; set; }
        [JsonPropertyName("RegisterDate")]
        public DateTime RegisterDate { get; set; }
        [JsonPropertyName("AccountType")]
        public int AccountType { get; set; }

        public BankAccount() { }

        public BankAccount(int accNo, int clId, int sta, float blnc, DateTime rgstDate, int accTpe)
        {
            AccountNumber = accNo;
            ClientId = clId;
            State = sta;
            Balance = blnc;
            RegisterDate = rgstDate;
            AccountType = accTpe;
        }
    }

    //class BList<A> : List<A>
    //{
    //    public int StatusCode { get; set; }

    //}

    //TransactionRequest
    class TransactionRequest
    {
        [JsonPropertyName("SessionToken")]
        public string SessionToken { get; set; }

        [JsonPropertyName("Transaction")]
        public Transaction Tran { get; set; }
        public TransactionRequest(string sesTok, Transaction trn)
        {
            SessionToken = sesTok;
            Tran = trn;
        }
    }

    //Transaction
    public class Transaction
    {
        [JsonPropertyName("Id")]
        public int TransactionId { get; set; }

        [JsonPropertyName("SourceAccountId")]
        public int SourceAccountId { get; set; }

        [JsonPropertyName("TargetAccountId")]
        public int TargetAccountId { get; set; }

        [JsonPropertyName("ProcessedDate")]
        public DateTime ProcessedDate { get; set; } = DateTime.Now;

        [JsonPropertyName("TransactionType")] // 1 es Deposito, 2 retiro, 3 cuentas tercero
        public int TransactionType { get; set; }

        [JsonPropertyName("Amount")]
        public float Amount { get; set; }

        public Transaction() { }
        public Transaction(int idd, int srcAccId, int tgtAccId, float amo, DateTime dia)
        {
            TransactionId = idd;
            SourceAccountId = srcAccId;
            TargetAccountId = tgtAccId;
            ProcessedDate = dia;
            TransactionType = 3;
            Amount = amo;
        }
    }

    //BankBeneficiary
    class BankBeneficiary
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("ClientId")]
        public int ClientId { get; set; }
        [JsonPropertyName("BankBeneficiaryAccountNumber")]
        public int AccountNumber { get; set; }
        [JsonPropertyName("Alias")]
        public string Alias { get; set; }
        [JsonPropertyName("RegisterDate")]
        public DateTime RegisterDate { get; set; }
        public BankBeneficiary() {}
        public BankBeneficiary(int cldId, int accNo, string alias, DateTime dia)
        {
            Id = cldId;
            ClientId = cldId;
            AccountNumber = accNo;
            Alias = alias;
            RegisterDate = dia;
        }

    }

    //BeneficiaryCreationRequest
    class BeneficiaryCreationRequest
    {
        [JsonPropertyName("SessionToken")]
        public string SessionToken { get; set; }
        [JsonPropertyName("Beneficiary")]
        public BankBeneficiary Bene { get; set; }
        public BeneficiaryCreationRequest(string sesTok, BankBeneficiary bBene)
        {
            SessionToken = sesTok;
            Bene = bBene;
        }
    }

    //TransactionsByAccountRequest
    class TransactionsByAccountRequest
    {
        [JsonPropertyName("SessionToken")]
        public string SessionToken { get; set; }

        [JsonPropertyName("AccountNumber")]
        public int AccountNumber { get; set; }

        public TransactionsByAccountRequest(string sesTok, int accNo)
        {
            SessionToken = sesTok;
            AccountNumber = accNo;
        }
    }

    //BeneficiaryByClientRequest
    class BeneficiaryByClientRequest
    {
        [JsonPropertyName("SessionToken")]
        public string SessionToken { get; set; }
        [JsonPropertyName("ClientId")]
        public int ClientId { get; set; }

        public BeneficiaryByClientRequest(string sesTok, int clId)
        {
            SessionToken = sesTok;
            ClientId = clId;
        }
    }

    //ListadoDePrestamos
    class LoansByClientRequest
    {
        [JsonPropertyName("SessionToken")]
        public string SessionToken { get; set; }
        [JsonPropertyName("ClientId")]
        public int ClientId { get; set; }

        public LoansByClientRequest(string sesTok, int clId)
        {
            SessionToken = sesTok;
            ClientId = clId;
        }
    }

    //Prestamo
    class BankLoan
    {
        [JsonPropertyName("Id")]
        public int LoanId { get; set; }

        [JsonPropertyName("SourceAccountId")] // Account from which the loan comes
        public int SourceAccountId { get; set; }

        [JsonPropertyName("ReceivingClientId")] // The client that owes the loan
        public int ReceivingClientId { get; set; }

        [JsonPropertyName("TotalLoanAmount")] // The total Amount owed
        public float TotalLoanAmount { get; set; }

        [JsonPropertyName("TotalPaidAmount")] // The total Amount paid
        public float TotalPaidAmount { get; set; }

        [JsonPropertyName("CreationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [JsonPropertyName("State")] // The state of the loan
        public int State { get; set; }

        [JsonPropertyName("Rate")] // The total Amount paid
        public float Rate { get; set; }
    }

    //PayLoanRequest
    class PayLoanRequest
    {
        [JsonPropertyName("SessionToken")]
        public string SessionToken { get; set; }
        [JsonPropertyName("LoanId")]
        public int LoanId { get; set; }
        [JsonPropertyName("SourceAccountId")]
        public int SourceAccountId { get; set; }
        [JsonPropertyName("PayAmount")]
        public float PayAmount { get; set; }
        public PayLoanRequest(string sesTok, int loId, int srcAcc, float amnt)
        {
            SessionToken = sesTok;
            LoanId = loId;
            SourceAccountId = srcAcc;
            PayAmount = amnt;
        }
    }
}