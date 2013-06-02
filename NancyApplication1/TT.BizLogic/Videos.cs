using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using TT.BizLogic.Dto;

namespace TT.BizLogic
{
    public class Videos : BaseBizObject
    {
        private readonly MongoCollection<VideoDto> _colVideos;

        public Videos()
        {
            _colVideos = _mongodb.GetCollection<VideoDto>("Videos");
        }

        public void AddVideo(VideoDto video)
        {
            _colVideos.Insert(video);
        }

        public List<VideoDto> GetAll()
        {
            return _colVideos.FindAll().ToList();
        }

    }
}
