using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersService.Dtos;

namespace UsersService.SyncDataService
{
    public interface ICommentDataClient
    {
        Task TotalCount(CreateCommentDtos request);
    }
}
