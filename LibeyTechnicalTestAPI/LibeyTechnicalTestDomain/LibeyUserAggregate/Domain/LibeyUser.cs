using System.ComponentModel;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain
{
    public class LibeyUser
    {
        public string DocumentNumber { get; private set; }
        public int DocumentTypeId { get; private set; }
        public string Name { get; private set; }
        public string FathersLastName { get; private set; }
        public string MothersLastName { get; private set; }
        public string Address { get; private set; }
        public string UbigeoCode { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }

        private readonly ILibeyUserRepository _repository;

        public LibeyUser() { }

        public LibeyUser(ILibeyUserRepository repository)
        {
            _repository = repository;
        }

        public void Find(string documentNumber)
        {
            var foundLibeyUser = _repository.Find(documentNumber);
            if (foundLibeyUser == null)
                throw new WarningException("No existe un usuario con el número de documento {0}", documentNumber);

            DocumentNumber = foundLibeyUser.DocumentNumber;

            _repository.ClearEF(foundLibeyUser);
        }

        public void InitializeCreate(string documentNumber, int documentTypeId, string name, string fathersLastName, string mothersLastName, string address,
        string ubigeoCode, string phone, string email, string password)
        {
            DocumentNumber = documentNumber;
            DocumentTypeId = documentTypeId;
            Name = name;
            FathersLastName = fathersLastName;
            MothersLastName = mothersLastName;
            Address = address;
            UbigeoCode = ubigeoCode;
            Phone = phone;
            Email = email;
            Password = password;
            Active = true;
        }

        public void InitializeUpdate(int documentTypeId, string name, string fathersLastName, string mothersLastName, string address,
        string ubigeoCode, string phone, string email, string password, bool active)
        {
            if (string.IsNullOrEmpty(DocumentNumber))
                throw new WarningException("Se requiere un número de documento.");
            DocumentTypeId = documentTypeId;
            Name = name;
            FathersLastName = fathersLastName;
            MothersLastName = mothersLastName;
            Address = address;
            UbigeoCode = ubigeoCode;
            Phone = phone;
            Email = email;
            Password = password;
            Active = active;

            _repository.Update(this);
        }
    }
}