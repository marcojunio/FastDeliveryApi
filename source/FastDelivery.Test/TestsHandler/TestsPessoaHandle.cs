using System.Threading.Tasks;
using FastDelivery.Domain.Commands;
using FastDelivery.Domain.Handlers;
using FastDelivery.Shared.ContractsCommand;
using FastDelivery.Test.FakeRepositories;
using Xunit;

namespace FastDelivery.Test.TestsHandle{ 
    public class TestsPessoaHandle{ 

        private readonly PessoaHandler _handle = new PessoaHandler(new FakePessoaRepository());
        private readonly CommandCreatePessoa commandValidCreate = new CommandCreatePessoa("teste","12364569852",20,"teste2","teste@gmail.com");
        private readonly CommandCreatePessoa commandInvalidCreate = new CommandCreatePessoa("","",20,"","teste@.com");

        [Fact]
        public async Task Deve_garantir_que_um_command_esteja_valido(){

            var result = (GenericCommandResult)await _handle.Handle(commandValidCreate);
            Assert.True(result.Success);
        }

         [Fact]
        public async Task Deve_garantir_que_um_command_esteja_invalido(){

            var result = (GenericCommandResult)await _handle.Handle(commandInvalidCreate);
            Assert.False(result.Success);
        }
    }
}