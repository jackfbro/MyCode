using MyCode.Data;
using MyCode.Model;
using MyCode.Model.SearchModel;
using MyCode.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCode.Service
{
    public class UserInfoService
    {
        private GenericRepository<UserInfo> _UserInfoRepository { get; set; }
        public UserInfoService()
        {
            _UserInfoRepository = new GenericRepository<UserInfo>();
        }

        public IEnumerable<UserInfo> GetPagedList(UserInfoSearch userInfoSearch,out int totalCount)
        {
            Expression<Func<UserInfo, bool>> search= Predicates.Begin<UserInfo>(true);
            if (!string.IsNullOrEmpty(userInfoSearch.Name))
            {
                search.And(m => m.Name.Contains(userInfoSearch.Name));
            }
            if (userInfoSearch.CreateTimeStart != null)
            {
                search.And(m => m.CreateTime > userInfoSearch.CreateTimeStart);
            }
            if (userInfoSearch.CreateTimeEnd != null)
            {
                search.And(m => m.CreateTime < userInfoSearch.CreateTimeEnd);
            }
            return _UserInfoRepository.GetPagedList(search, m => m.CreateTime, true, 1, 10, out totalCount).ToList();
        }
    }
}
