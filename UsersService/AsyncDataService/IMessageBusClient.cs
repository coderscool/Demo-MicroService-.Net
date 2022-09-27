using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersService.Dtos;

namespace UsersService.AsyncDataService
{
    public interface IMessageBusClient
    {
        void PublishSetTotal(CommentPublish request);
    }
}
