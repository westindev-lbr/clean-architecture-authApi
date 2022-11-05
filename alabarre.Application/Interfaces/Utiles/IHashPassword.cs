namespace alabarre.Application.Intefaces.Utiles;

public interface IHashPassword {
    string HashPasswd(string password);
    string GenerateSalt(int byteLength);
}