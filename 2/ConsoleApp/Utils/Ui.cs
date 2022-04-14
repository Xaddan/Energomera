using System;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Items.Commands.Create;
using Application.Items.Commands.Remove;
using Application.Items.Commands.Update;
using Application.Items.Queries.GetAll;
using Application.Items.Queries.GetById;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static System.Int32;
using static System.String;

namespace ConsoleApp.Utils
{
    public class Ui : IHostedService
    {
        private readonly IMediator _mediator;
        private readonly Table _table;

        public Ui(IServiceScopeFactory serviceScopeFactory)
        {
            var scope = serviceScopeFactory.CreateScope();
            _mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            _table = new Table();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                Header();

                var select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        await GetAll();
                        break;
                    case "2":
                        await Get();
                        break;
                    case "3":
                        await Add();
                        break;
                    case "4":
                        await Update();
                        break;
                    case "5":
                        await Remove();
                        break;
                    case "6":
                        return;
                    default:
                        break;
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void Header()
        {
            Console.Clear();
            Console.WriteLine("Выберите операцию");
            Console.WriteLine("1 - Показать все записи\n2 - Показать запись по Id\n3 - Добавить новую запись\n4 - Изменить запись\n5 - Удалить запись\n6 - Выйти");
        }
        
        private async Task GetAll()
        {
            Console.Clear();

            var request = new GetAllRequest();

            var result = await _mediator.Send(request);
            DrawTable(result);

            Console.ReadKey();
        }

        private async Task Get()
        {
            Console.Clear();

            Console.WriteLine("Введите Id");
            TryParse(Console.ReadLine(), out var id);

            var request = new GetByIdRequest
            {
                Id = id
            };

            var result = await _mediator.Send(request);
            DrawTable(result);

            Console.ReadKey();
        }

        private async Task Add()
        {
            Console.Clear();

            Console.WriteLine("Введите новый Name");
            var name = Console.ReadLine();

            var request = new CreateRequest
            {
                Name = name,
            };

            await _mediator.Send(request);
        }

        private async Task Update()
        {
            Console.Clear();

            Console.WriteLine("Введите Id изменяемого Item");
            TryParse(Console.ReadLine(), out var id);

            Console.WriteLine("Введите новое значение Name");
            var name = Console.ReadLine();

            var request = new UpdateRequest
            {
                Id = id,
                Name = name,
            };

            var result = await _mediator.Send(request);
            DrawTable(result);

            Console.ReadKey();
        }

        private async Task Remove()
        {
            Console.Clear();

            Console.WriteLine("Введите Id удаляемого Item");
            TryParse(Console.ReadLine(), out var id);

            var request = new RemoveRequest
            {
                Id = id
            };

            var result = await _mediator.Send(request);
            DrawTable(result);

            Console.ReadKey();
        }

        private void DrawTable<T>(Result<T> result)
        {
            if (!result.IsSuccess)
            {
                Console.WriteLine(Join(',', result.Errors.Select(e => e.Value).ToList()));
                return;
            }

            _table.ClearRows();

            if (result.Entity is IEnumerable entitys)
            {
                foreach (var entity in entitys)
                {
                    _table.SetHeaders(entity.GetType().GetProperties().Select(p => p.Name).ToArray());
                    _table.AddRow(entity.GetType().GetProperties().Select(p => p.GetValue(entity)?.ToString())
                        .ToArray());
                }
            }
            else
            {
                _table.SetHeaders(result.Entity.GetType().GetProperties().Select(p => p.Name).ToArray());
                _table.AddRow(result.Entity.GetType().GetProperties().Select(p => p.GetValue(result.Entity)?.ToString())
                    .ToArray());
            }

            Console.WriteLine(_table.ToString());
        }

        private void DrawTable(Result result)
        {
            if (!result.IsSuccess)
            {
                Console.WriteLine(Join(',', result.Errors.Select(e => e.Value).ToList()));
            }
        }
    }
}