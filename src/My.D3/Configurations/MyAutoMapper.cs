using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My.D3.Entity.Demo;
using My.D3.Entity.Demo.Dto;
using My.D3.Entity.Demo.View;

namespace My.D3.Configurations
{
    public class MyAutoMapper : Profile
    {
        public MyAutoMapper()
        {
            //  可以给lambda表达式
            //CreateMap<DateTime, string>().ConvertUsing(x => x.ToString("yyyy-MM-dd HH:mm:ss"));
            //实现接口
            //CreateMap<DateTime, string>().ConvertUsing<DateTimeTypeConverter>();
            //实体和Dto的相互转化
            CreateMap<DemoStudentEntity, DemoStudentDto>().ReverseMap();
            CreateMap<ViewDemoStudent, ViewDemoStudentDto>().ReverseMap();


        }


    }
}
