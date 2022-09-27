using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PostsService.Data;
using PostsService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PostsService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public EventProcessor(IServiceScopeFactory scopeFactory )
        {
            _scopeFactory = scopeFactory;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.PostPublished:
                    UpCount(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notifcationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonConvert.DeserializeObject<GenericMessageDto>(notifcationMessage);

            switch (eventType.Event)
            {
                case "Comment_Published":
                    Console.WriteLine("--> Post Published Event Detected");
                    return EventType.PostPublished;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private void UpCount(string Message)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IPostsService>();

                var result = JsonConvert.DeserializeObject<GenericMessageDto>(Message);

                Console.WriteLine($"--> Get Result! {result.Event}" );

                try
                {
                    var data = new GenericMessageDto()
                    {
                        Event = result.Event,
                        PostId = result.PostId
                    };
                    if (data != null)
                    {
                        repo.Create(result.PostId);
                        repo.SaveChange();
                        Console.WriteLine("--> Platform added!", data);
                    }
                    else
                    {
                        Console.WriteLine("--> Platform already exisits...");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add Platform to DB {ex.Message}");
                }
            }
        }
    }

    enum EventType
    {
        PostPublished,
        Undetermined
    }
}
