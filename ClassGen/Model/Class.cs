using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClassGen.Model
{
    public enum Term
    {
        first=3,
        seconed=12,
        shor=16
    }
    public class Class
    {
        public string cd_id { get; set; }
        public string cdmc { get; set; }
        public string jc { get; set; }
        public string jcor { get; set; }
        public string jcs { get; set; }
        public string jgh_id { get; set; }
        public string jgpxzd { get; set; }
        public string jxb_id { get; set; }
        public string jxbmc { get; set; }
        public string kch_id { get; set; }
        public string kcmc { get; set; }
        public string khfsmc { get; set; }
        public string listnav { get; set; }
        public string localeKey { get; set; }
        public bool pageable { get; set; }
        public string pkbj { get; set; }
        public bool rangeable { get; set; }
        public int rsdzjs { get; set; }
        public string sxbj { get; set; }
        public string totalResult { get; set; }
        public string xm { get; set; }
        public string xnm { get; set; }
        public string xqdm { get; set; }
        public string xqh_id { get; set; }
        public string xqj { get; set; }
        public string xqjmc { get; set; }
        public string xqm { get; set; }
        public string xqmc { get; set; }
        public string xsdm { get; set; }
        public string xslxbj { get; set; }
        public string zcd { get; set; }
        public string zcmc { get; set; }
        public string zyfxmc { get; set; }
        public string name { get; set; }
        public string collage { get; set; }
        public string classinfo { get; set; }
        public string classtype { get; set; }
        public int classscore { get; set; }
        public int classhuor { get; set; }

        public static List<Class> Serializer(string msg)
        {
            var classlist = new List<Class>();
            //反序列化JSON 方法一
            DataContractJsonSerializer seriliazer = new DataContractJsonSerializer(typeof(List<Class>));
            
            //将json字符串转化为byte[] 来作为参数实例化MemoryStream
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(msg)))
            {
                classlist = seriliazer.ReadObject(ms) as List<Class>;
            }
            return classlist;
        }

    }
}
