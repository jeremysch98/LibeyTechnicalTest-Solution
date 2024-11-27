using System.ComponentModel;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        public LibeyUserAggregate(ILibeyUserRepository repository)
        {
            _repository = repository;
        }

        public List<LibeyUserResponse> GetAll()
        {
            return _repository.GetAll();
        }

        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }

        public void Create(UserUpdateorCreateCommand command)
        {
            if (string.IsNullOrEmpty(command.DocumentNumber))
                throw new WarningException("Se requiere un número de documento.");

            if (!string.IsNullOrEmpty(command.DocumentNumber))
            {
                var exist = _repository.ExistLibeyUserDocumentNumber(command.DocumentNumber);
                if (exist)
                    throw new WarningException("Este número de documento ya se encuentra registrado");
            }

            LibeyUser libeyUser = new LibeyUser();
            libeyUser.InitializeCreate(command.DocumentNumber, command.DocumentTypeId, command.Name, command.FathersLastName, command.MothersLastName, command.Address, command.UbigeoCode, command.Phone, command.Email, command.Password);

            _repository.Create(libeyUser);
        }

        public void Update(UserUpdateorCreateCommand command)
        {
            LibeyUser libeyUser = new LibeyUser(_repository);
            libeyUser.Find(command.DocumentNumber);

            libeyUser.InitializeUpdate(command.DocumentTypeId, command.Name, command.FathersLastName, command.MothersLastName, command.Address, command.UbigeoCode, command.Phone, command.Email, command.Password, command.Active);

            //_repository.Update(libeyUser);
        }
    }
}