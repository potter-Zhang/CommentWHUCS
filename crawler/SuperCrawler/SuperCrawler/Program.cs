using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;
using SuperCrawler;
using System;
using System.IO;

namespace final
{
    public class SuperCrawler
    {
       
        
        public static void Main()
        {
            //string JosnStr = HttpPost("https://jwgl.whu.edu.cn/design/funcData_cxFuncDataList.html?func_widget_guid=CABE8E78D4456040E0530207010A5E49&gnmkdm=N214599&su=2021302111460", "xnm=2022&jg_id=21&_search=false&nd=1683248629044&queryModel.showCount=100&queryModel.currentPage=1&queryModel.sortName=&queryModel.sortOrder=asc");
            //HttpGet("https://cs.whu.edu.cn/szdw/zrjs.htm", "C:\\Users\\Harry\\Desktop\\teacherInfo.txt");
            //Console.WriteLine(JosnStr);
            //string JosnStr = "{\"currentPage\":1,\"currentResult\":0,\"entityOrField\":false,\"items\":[{\"xsdm_01\":40,\"xsdm_04\":12,\"jszc\":\"讲师\",\"tue\":\"1-11周6-8节3区1-425(139,多媒体)\",\"kkbm_id\":\"58\",\"mon\":\"1-11周3-5节3区1-425(139,多媒体)\",\"jhxy\":\"计算机学院\",\"jsxm\":\"杜蘅\",\"xqm\":\"3\",\"njdm_id\":\"2021\",\"jg_id\":\"21\",\"zyh_id\":\"184\",\"kclbmc\":\"无\",\"bz\":\"第5.8周为实践教学\",\"kklxdm\":\"01\",\"kcmc\":\"毛泽东思想和中国特色社会主义理论体系概论\",\"totalresult\":552,\"key\":\"DEB86D3F1AC13142E0530207010A343207013184\",\"kcxzdm\":\"0000\",\"kkbm_id2\":\"-21--58-\",\"jxbmc\":\"(2022-2023-1)-1100890011004-37\",\"yskch\":\"1000890011010\",\"kclbdm\":\"00\",\"skxy\":\"公共政治教学\",\"skrs\":\"100\\\\100\",\"kklxmc\":\"专业教育课程\",\"kcxzmc\":\"公共基础必修\",\"kcxf\":\"3.0\",\"cbs\":\"‎高等教育出版社\",\"xnm\":\"2022\",\"xn\":\"2022-2023\",\"xq\":\"1\",\"jszy\":\"计算机科学与技术\",\"nj\":\"2021\",\"row_id\":1,\"jcmc\":\"毛泽东思想和中国特色社会主义理论体系概论\"},{\"xsdm_01\":40,\"xsdm_04\":12,\"jszc\":\"讲师\",\"tue\":\"1-11周6-8节3区1-425(139,多媒体)\",\"kkbm_id\":\"58\",\"mon\":\"1-11周3-5节3区1-425(139,多媒体)\",\"jhxy\":\"计算机学院\",\"jsxm\":\"杜蘅\",\"xqm\":\"3\",\"njdm_id\":\"2021\",\"jg_id\":\"21\",\"zyh_id\":\"812\",\"kclbmc\":\"无\",\"bz\":\"第5.8周为实践教学\",\"kklxdm\":\"01\",\"kcmc\":\"毛泽东思想和中国特色社会主义理论体系概论\",\"totalresult\":552,\"key\":\"DEB86D3F1AC13142E0530207010A343207013812\",\"kcxzdm\":\"0000\",\"kkbm_id2\":\"-21--58-\",\"jxbmc\":\"(2022-2023-1)-1100890011004-37\",\"yskch\":\"1000890011010\",\"kclbdm\":\"00\",\"skxy\":\"公共政治教学\",\"skrs\":\"100\\\\100\",\"kklxmc\":\"专业教育课程\",\"kcxzmc\":\"公共基础必修\",\"kcxf\":\"3.0\",\"cbs\":\"‎高等教育出版社\",\"xnm\":\"2022\",\"xn\":\"2022-2023\",\"xq\":\"1\",\"jszy\":\"人工智能\",\"nj\":\"2021\",\"row_id\":2,\"jcmc\":\"毛泽东思想和中国特色社会主义理论体系概论\"},{\"xsdm_01\":40,\"xsdm_04\":12,\"jszc\":\"副教授\",\"tue\":\"1-11周6-8节3区1-428(210,多媒体)\",\"kkbm_id\":\"58\",\"mon\":\"1-11周3-5节3区1-428(210,多媒体)\",\"jhxy\":\"计算机学院\",\"jsxm\":\"龚玉敏\",\"xqm\":\"3\",\"njdm_id\":\"2021\",\"jg_id\":\"21\",\"zyh_id\":\"342\",\"kclbmc\":\"无\",\"bz\":\"第5.8周为实践教学\",\"kklxdm\":\"01\",\"kcmc\":\"毛泽东思想和中国特色社会主义理论体系概论\",\"totalresult\":552,\"key\":\"DEB79A817083C762E0530207010AD70E07017342\",\"kcxzdm\":\"0000\",\"kkbm_id2\":\"-21--58-\",\"jxbmc\":\"(2022-2023-1)-1100890011004-36\",\"yskch\":\"1000890011010\",\"kclbdm\":\"00\",\"skxy\":\"公共政治教学\",\"skrs\":\"136\\\\138\",\"kklxmc\":\"专业教育课程\",\"kcxzmc\":\"公共基础必修\",\"kcxf\":\"3.0\",\"cbs\":\"‎高等教育出版社\",\"xnm\":\"2022\",\"xn\":\"2022-2023\",\"xq\":\"1\",\"jszy\":\"软件工程\",\"nj\":\"2021\",\"row_id\":3,\"jcmc\":\"毛泽东思想和中国特色社会主义理论体系概论\"},{\"xsdm_01\":40,\"xsdm_04\":12,\"jszc\":\"副教授\",\"kkbm_id\":\"58\",\"mon\":\"1-16周6-8节3区1-710(240,多媒体)\",\"jhxy\":\"计算机学院\",\"jsxm\":\"李玲\",\"xqm\":\"3\",\"njdm_id\":\"2022\",\"jg_id\":\"21\",\"zyh_id\":\"656\",\"kclbmc\":\"大类平台\",\"bz\":\"第5.8.12周为实践教学\",\"kklxdm\":\"01\",\"kcmc\":\"思想道德与法治\",\"totalresult\":552,\"key\":\"DEB75F909C5A9670E0530207010AE51707032656\",\"kcxzdm\":\"0000\",\"kkbm_id2\":\"-21--58-\",\"jxbmc\":\"(2022-2023-1)-1100890011009-50\",\"yskch\":\"1100890011009\",\"kclbdm\":\"05\",\"skxy\":\"公共政治教学\",\"skrs\":\"130\\\\110\",\"kklxmc\":\"专业教育课程\",\"kcxzmc\":\"公共基础必修\",\"kcxf\":\"3.0\",\"cbs\":\"高等教育出版社\",\"xnm\":\"2022\",\"xn\":\"2022-2023\",\"xq\":\"1\",\"jszy\":\"计算机类\",\"nj\":\"2022\",\"row_id\":4,\"jcmc\":\"思想道德与法治\"},{\"xsdm_01\":40,\"xsdm_04\":12,\"jszc\":\"讲师\",\"tue\":\"1-11周,13-16周6-8节3区1-401(240,多媒体)\",\"kkbm_id\":\"58\",\"sun\":\"11周6-8节3区1-401(240,多媒体)\",\"jhxy\":\"计算机学院\",\"jsxm\":\"徐嘉鸿\",\"xqm\":\"12\",\"njdm_id\":\"2022\",\"jg_id\":\"21\",\"zyh_id\":\"656\",\"kclbmc\":\"无\",\"kklxdm\":\"01\",\"kcmc\":\"中国近现代史纲要\",\"totalresult\":552,\"key\":\"EC9C2C1A90A97A5FE0530207010AA79107147656\",\"kcxzdm\":\"0000\",\"kkbm_id2\":\"-21--58-\",\"jxbmc\":\"(2022-2023-2)-1100890011002-54\",\"yskch\":\"1100890011002\",\"kclbdm\":\"00\",\"skxy\":\"公共政治教学\",\"skrs\":\"100\\\\101\",\"kklxmc\":\"专业教育课程\",\"kcxzmc\":\"公共基础必修\",\"kcxf\":\"3.0\",\"cbs\":\"高等教育出版社\",\"xnm\":\"2022\",\"xn\":\"2022-2023\",\"xq\":\"2\",\"jszy\":\"计算机类\",\"nj\":\"2022\",\"row_id\":5,\"jcmc\":\"中国近现代史纲要（2021年版）\"},{\"xsdm_01\":40,\"xsdm_04\":12,\"jszc\":\"副教授\",\"tue\":\"1-11周6-8节3区1-401(240,多媒体)\",\"kkbm_id\":\"58\",\"mon\":\"1-11周3-5节3区1-301(240,多媒体)\",\"jhxy\":\"计算机学院\",\"jsxm\":\"吴向伟\",\"xqm\":\"3\",\"njdm_id\":\"2021\",\"jg_id\":\"21\",\"zyh_id\":\"184\",\"kclbmc\":\"无\",\"bz\":\"第5.8周为实践教学\",\"kklxdm\":\"01\",\"kcmc\":\"毛泽东思想和中国特色社会主义理论体系概论\",\"totalresult\":552,\"key\":\"DEB7A4128DABD089E0530207010A36AC07093184\",\"kcxzdm\":\"0000\",\"kkbm_id2\":\"-21--58-\",\"jxbmc\":\"(2022-2023-1)-1100890011004-33\",\"yskch\":\"1000890011010\",\"kclbdm\":\"00\",\"skxy\":\"公共政治教学\",\"skrs\":\"120\\\\124\",\"kklxmc\":\"专业教育课程\",\"kcxzmc\":\"公共基础必修\",\"kcxf\":\"3.0\",\"cbs\":\"‎高等教育出版社\",\"xnm\":\"2022\",\"xn\":\"2022-2023\",\"xq\":\"1\",\"jszy\":\"计算机科学与技术\",\"nj\":\"2021\",\"row_id\":6,\"jcmc\":\"毛泽东思想和中国特色社会主义理论体系概论\"},{\"xsdm_01\":48,\"jszc\":\"教授\",\"kkbm_id\":\"58\",\"mon\":\"1-8周3-5节3区1-427(240,多媒体)\",\"jhxy\":\"计算机学院\",\"jsxm\":\"刘明松\",\"xqm\":\"12\",\"njdm_id\":\"2020\",\"jg_id\":\"21\",\"zyh_id\":\"342\",\"kclbmc\":\"无\",\"kklxdm\":\"01\",\"kcmc\":\"习近平新时代中国特色社会主义思想概论\",\"totalresult\":552,\"key\":\"ECF12B427C4EA37AE0530107010A864D07045342\",\"wen\":\"1-8周3-5节国软4-304(200,多媒体)\",\"kcxzdm\":\"0000\",\"kkbm_id2\":\"-21--58-\",\"jxbmc\":\"(2022-2023-2)-1000890011009-97\",\"yskch\":\"1000890011009\",\"kclbdm\":\"00\",\"skxy\":\"公共政治教学\",\"skrs\":\"120\\\\117\",\"kklxmc\":\"专业教育课程\",\"kcxzmc\":\"公共基础必修\",\"kcxf\":\"3.0\",\"cbs\":\"无\",\"xnm\":\"2022\",\"xn\":\"2022-2023\",\"xq\":\"2\",\"jszy\":\"软件工程\",\"nj\":\"2020\",\"row_id\":7,\"jcmc\":\"无教材\"},{\"xsdm_01\":40,\"xsdm_04\":12,\"jszc\":\"教授\",\"kkbm_id\":\"58\",\"mon\":\"1-16周3-5节3区2-204(100,多媒体)\",\"jhxy\":\"计算机学院\",\"jsxm\":\"杨虹\",\"xqm\":\"12\",\"njdm_id\":\"2022\",\"jg_id\":\"21\",\"zyh_id\":\"656\",\"kclbmc\":\"无\",\"kklxdm\":\"01\",\"kcmc\":\"马克思主义基本原理\",\"totalresult\":552,\"key\":\"EC9B3691013D1563E0530107010A1FC207105656\",\"kcxzdm\":\"0000\",\"kkbm_id2\":\"-21--58-\",\"jxbmc\":\"(2022-2023-2)-1100890011008-64\",\"yskch\":\"1100890011008\",\"kclbdm\":\"00\",\"skxy\":\"公共政治教学\",\"skrs\":\"99\\\\100\",\"kklxmc\":\"专业教育课程\",\"kcxzmc\":\"公共基础必修\",\"kcxf\":\"3.0\",\"cbs\":\"高等教育出版社\",\"xnm\":\"2022\",\"xn\":\"2022-2023\",\"xq\":\"2\",\"jszy\":\"计算机类\",\"nj\":\"2022\",\"row_id\":8,\"jcmc\":\"马克思主义基本原理（2021年版）\"},{\"xsdm_01\":40,\"xsdm_04\":12,\"jszc\":\"副教授\",\"tue\":\"1-11周,13-16周6-8节3区2-217(117,多媒体)\",\"kkbm_id\":\"58\",\"sun\":\"11周6-8节3区2-217(117,多媒体)\",\"jhxy\":\"计算机学院\",\"jsxm\":\"万军杰\",\"xqm\":\"12\",\"njdm_id\":\"2022\",\"jg_id\":\"21\",\"zyh_id\":\"656\",\"kclbmc\":\"无\",\"kklxdm\":\"01\",\"kcmc\":\"中国近现代史纲要\",\"totalresult\":552,\"key\":\"EC9BBD48163194C5E0530107010AFD7407086656\",\"kcxzdm\":\"0000\",\"kkbm_id2\":\"-21--58-\",\"jxbmc\":\"(2022-2023-2)-1100890011002-51\",\"yskch\":\"1100890011002\",\"kclbdm\":\"00\",\"skxy\":\"公共政治教学\",\"skrs\":\"99\\\\99\",\"kklxmc\":\"专业教育课程\",\"kcxzmc\":\"公共基础必修\",\"kcxf\":\"3.0\",\"cbs\":\"高等教育出版社\",\"xnm\":\"2022\",\"xn\":\"2022-2023\",\"xq\":\"2\",\"jszy\":\"计算机类\",\"nj\":\"2022\",\"row_id\":9,\"jcmc\":\"中国近现代史纲要（2021年版）\"},{\"xsdm_01\":48,\"jszc\":\"教授\",\"kkbm_id\":\"58\",\"mon\":\"9-16周3-5节3区1-427(240,多媒体)\",\"jhxy\":\"计算机学院\",\"jsxm\":\"刘明松\",\"xqm\":\"12\",\"njdm_id\":\"2021\",\"jg_id\":\"21\",\"zyh_id\":\"342\",\"kclbmc\":\"无\",\"kklxdm\":\"01\",\"kcmc\":\"习近平新时代中国特色社会主义思想概论\",\"totalresult\":552,\"key\":\"ECF0A15EB4092A67E0530107010A3AC907045342\",\"wen\":\"9-11周,13-16周3-5节国软4-304(200,多媒体)\",\"kcxzdm\":\"0000\",\"kkbm_id2\":\"-21--58-\",\"jxbmc\":\"(2022-2023-2)-1000890011009-91\",\"sat\":\"12周3-5节国软4-304(200,多媒体)\",\"yskch\":\"1000890011009\",\"kclbdm\":\"00\",\"skxy\":\"公共政治教学\",\"skrs\":\"120\\\\120\",\"kklxmc\":\"专业教育课程\",\"kcxzmc\":\"公共基础必修\",\"kcxf\":\"3.0\",\"cbs\":\"无\",\"xnm\":\"2022\",\"xn\":\"2022-2023\",\"xq\":\"2\",\"jszy\":\"软件工程\",\"nj\":\"2021\",\"row_id\":10,\"jcmc\":\"无教材\"},{\"xsdm_01\":40,\"xsdm_04\":12,\"jszc\":\"副教授\",\"kkbm_id\":\"58\",\"mon\":\"1-16周3-5节3区1-325(124,多媒体)\",\"jhxy\":\"计算机学院\",\"jsxm\":\"黄沁茗\",\"xqm\":\"12\",\"njdm_id\":\"2022\",\"jg_id\":\"21\",\"zyh_id\":\"656\",\"kclbmc\":\"无\",\"kklxdm\":\"01\",\"kcmc\":\"马克思主义基本原理\",\"totalresult\":552,\"key\":\"EC9C6A85A9013532E0530107010AD34007024656\",\"kcxzdm\":\"0000\",\"kkbm_id2\":\"-21--58-\",\"jxbmc\":\"(2022-2023-2)-1100890011008-65\",\"yskch\":\"1100890011008\",\"kclbdm\":\"00\",\"skxy\":\"公共政治教学\",\"skrs\":\"99\\\\101\",\"kklxmc\":\"专业教育课程\",\"kcxzmc\":\"公共基础必修\",\"kcxf\":\"3.0\",\"cbs\":\"高等教育出版社\",\"xnm\":\"2022\",\"xn\":\"2022-2023\",\"xq\":\"2\",\"jszy\":\"计算机类\",\"nj\":\"2022\",\"row_id\":11,\"jcmc\":\"马克思主义基本原理（2021年版）\"},{\"xsdm_01\":48,\"jszc\":\"副教授\",\"kkbm_id\":\"58\",\"mon\":\"9-16周3-5节3区1-302(206,多媒体)\",\"jhxy\":\"计算机学院\",\"jsxm\":\"范卫青\",\"xqm\":\"12\",\"njdm_id\":\"2021\",\"jg_id\":\"21\",\"zyh_id\":\"342\",\"kclbmc\":\"无\",\"kklxdm\":\"01\",\"kcmc\":\"习近平新时代中国特色社会主义思想概论\",\"totalresult\":552,\"key\":\"ECF0A15EB3F92A67E0530107010A3AC907014342\",\"wen\":\"9-11周,13-16周3-5节国软4-404(200,多媒体)\",\"kcxzdm\":\"0000\",\"kkbm_id2\":\"-21--58-\",\"jxbmc\":\"(2022-2023-2)-1000890011009-88\",\"sat\":\"12周3-5节国软4-404(200,多媒体)\",\"yskch\":\"1000890011009\",\"kclbdm\":\"00\",\"skxy\":\"公共政治教学\",\"skrs\":\"120\\\\120\",\"kklxmc\":\"专业教育课程\",\"kcxzmc\":\"公共基础必修\",\"kcxf\":\"3.0\",\"cbs\":\"无\",\"xnm\":\"2022\",\"xn\":\"2022-2023\",\"xq\":\"2\",\"jszy\":\"软件工程\",\"nj\":\"2021\",\"row_id\":12,\"jcmc\":\"无教材\"},{\"xsdm_01\":40,\"xsdm_04\":12,\"jszc\":\"讲师\",\"kkbm_id\":\"58\",\"mon\":\"1-16周3-5节3区1-301(240,多媒体)\",\"jhxy\":\"计算机学院\",\"jsxm\":\"张萌\",\"xqm\":\"12\",\"njdm_id\":\"2022\",\"jg_id\":\"21\",\"zyh_id\":\"656\",\"kclbmc\":\"无\",\"kklxdm\":\"01\",\"kcmc\":\"马克思主义基本原理\",\"totalresult\":552,\"key\":\"EC9CDAA9936A94E9E0530107010A582707162656\",\"kcxzdm\":\"0000\",\"kkbm_id2\":\"-21--58-\",\"jxbmc\":\"(2022-2023-2)-1100890011008-63\",\"yskch\":\"1100890011008\",\"kclbdm\":\"00\",\"skxy\":\"公共政治教学\",\"skrs\":\"102\\\\102\",\"kklxmc\":\"专业教育课程\",\"kcxzmc\":\"公共基础必修\",\"kcxf\":\"3.0\",\"cbs\":\"高等教育出版社\",\"xnm\":\"2022\",\"xn\":\"2022-2023\",\"xq\":\"2\",\"jszy\":\"计算机类\",\"nj\":\"2022\",\"row_id\":13,\"jcmc\":\"马克思主义基本原理（2021年版）\"},{\"xsdm_01\":40,\"xsdm_04\":12,\"jszc\":\"副教授\",\"kkbm_id\":\"58\",\"mon\":\"1-16周6-8节3区1-402(203,多媒体)\",\"jhxy\":\"计算机学院\",\"jsxm\":\"黄代翠\",\"xqm\":\"3\",\"njdm_id\":\"2022\",\"jg_id\":\"21\",\"zyh_id\":\"656\",\"kclbmc\":\"大类平台\",\"bz\":\"第5.8.12周为实践教学\",\"kklxdm\":\"01\",\"kcmc\":\"思想道德与法治\",\"totalresult\":552,\"key\":\"DEB79A81706FC762E0530207010AD70E07023656\",\"kcxzdm\":\"0000\",\"kkbm_id2\":\"-21--58-\",\"jxbmc\":\"(2022-2023-1)-1100890011009-53\",\"yskch\":\"1100890011009\",\"kclbdm\":\"05\",\"skxy\":\"公共政治教学\",\"skrs\":\"135\\\\135\",\"kklxmc\":\"专业教育课程\",\"kcxzmc\":\"公共基础必修\",\"kcxf\":\"3.0\",\"cbs\":\"高等教育出版社\",\"xnm\":\"2022\",\"xn\":\"2022-2023\",\"xq\":\"1\",\"jszy\":\"计算机类\",\"nj\":\"2022\",\"row_id\":14,\"jcmc\":\"思想道德与法治\"},{\"xsdm_01\":40,\"xsdm_04\":12,\"jszc\":\"副教授\",\"tue\":\"1-11周6-8节3区2-101(216,多媒体)\",\"kkbm_id\":\"58\",\"mon\":\"1-11周3-5节3区2-101(216,多媒体)\",\"jhxy\":\"计算机学院\",\"jsxm\":\"王双群\",\"xqm\":\"3\",\"njdm_id\":\"2021\",\"jg_id\":\"21\",\"zyh_id\":\"342\",\"kclbmc\":\"无\",\"bz\":\"第5.8周为实践教学\",\"kklxdm\":\"01\",\"kcmc\":\"毛泽东思想和中国特色社会主义理论体系概论\",\"totalresult\":552,\"key\":\"DEB86D3F1ABE3142E0530207010A343207089342\",\"kcxzdm\":\"0000\",\"kkbm_id2\":\"-21--58-\",\"jxbmc\":\"(2022-2023-1)-1100890011004-35\",\"yskch\":\"1000890011010\",\"kclbdm\":\"00\",\"skxy\":\"公共政治教学\",\"skrs\":\"135\\\\135\",\"kklxmc\":\"专业教育课程\",\"kcxzmc\":\"公共基础必修\",\"kcxf\":\"3.0\",\"cbs\":\"‎高等教育出版社\",\"xnm\":\"2022\",\"xn\":\"2022-2023\",\"xq\":\"1\",\"jszy\":\"软件工程\",\"nj\":\"2021\",\"row_id\":15,\"jcmc\":\"毛泽东思想和中国特色社会主义理论体系概论\"}],\"limit\":15,\"offset\":0,\"pageNo\":0,\"pageSize\":15,\"showCount\":15,\"sortName\":\"skxy\",\"sortOrder\":\"asc\",\"sorts\":[],\"totalCount\":552,\"totalPage\":37,\"totalResult\":552}";
            //Josn2Object(JosnStr);
            //Console.WriteLine(ChineseConvert.Name2Pinyin("牛晓光"));
            //GetDblp("C:\\Users\\Harry\\Desktop\\pinyin.txt");
            //DataReader.ReadFromCsv("server=localhost;uid=root;password=lpWZ38sql;database=tdb", "C:\\Users\\Harry\\Desktop\\teacherInfo.csv");
            //"C:\\Users\\Harry\\source\\repos\\crawler-master\\crawler-master"
            HttpGetImg("https://cs.whu.edu.cn/szdw/zrjs.htm", "C:\\Users\\Harry\\Desktop\\img\\");
        }

        public static void GetPinyin()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            FileStream fs = new FileStream("C:\\Users\\Harry\\Desktop\\teacherInfo.csv", FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"));
            StreamWriter sw = new StreamWriter("C:\\Users\\Harry\\Desktop\\pinyin.txt");
            string str = "";
            sr.ReadLine();
            while ((str = sr.ReadLine()) != null)
            {


                string[] line = str.Split(',');
                Console.WriteLine(line[0]);
                Console.WriteLine(ChineseConvert.Name2Pinyin(line[0]));
            }
            sw.Flush();
            sw.Close();
        }
        //Value = "<p>Exact matches</p><ul class=\"result-list\"><li itemscope itemtype=\"http://schema.org/Person\"><link itemprop=\"additionalType\" href=\"https://dblp.org/rdf/schema#Person\"><a href=\"https://dblp.org/pid/85/5901\" itemprop=\"url\"><span itemprop=\"name\...

        public static string HttpPreview()
        {
            string url = "https://jwgl.whu.edu.cn/design/funcData_cxFuncDataList.html?func_widget_guid=CABE8E78D4456040E0530207010A5E49&gnmkdm=N214599&su=2021302111460";
            string postStr = "xnm=2022&jg_id=21&_search=false&nd=1683248629044&queryModel.showCount=15&queryModel.currentPage=1&queryModel.sortName=&queryModel.sortOrder=asc";
            byte[] postData = Encoding.UTF8.GetBytes(postStr);
            WebClient webClient = new WebClient();
            webClient.Headers.Add("ContentType", "application/json; charset=utf-8");
            webClient.Headers.Add("Cookie", "");
            return "";
        }

        public static void GetDblp(string file)
        {
            StreamReader sd = new StreamReader(file);
            StreamWriter sw = new StreamWriter("C:\\Users\\Harry\\Desktop\\dblp.txt");
            WebClient wb = new WebClient();
            wb.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36");
            wb.Headers.Add("Cookie", "dblp-search-mode=c; dblp-view=y; dblp-dismiss-new-feature-2022-01-27=true");
            string url = "https://dblp.uni-trier.de/search/author/inc?q=";//"https://dblp.uni-trier.de/search?q=";//"https://dblp.uni-trier.de/search?q=";//"https://dblp.org/search/author/inc?q=";
            string pattern = @"<p>Exact matches</p><ul class=""result-list"">(?<items>.+?)</ul>";//@"<p>Exact matches.+?<a href=[""](?<site>.+?)[""] itemprop=[""]url[""]>";
            string subPattern = @"<li.*?<a href=[""](?<link>.*?)[""].*?<small>(?<university>.*?)</small>.*?</li>";
            string name = "";
            while ((name = sd.ReadLine()) != null)
            {

                string q = url + name + "&s=0";
                //https://dblp.org/search/author/inc?q=zuchao%20li&s=1
                //https://dblp.org/search?q=zuchao%20li
                q = Uri.EscapeUriString(q);

                //HttpWebRequest request = WebRequest.Create(q) as HttpWebRequest;
                //request.Method = "GET";
                //request.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36";
                //request.Headers["Cookie"] = "dblp-search-mode=c; dblp-view=y; dblp-dismiss-new-feature-2022-01-27=true";
                //request.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7";

                //HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Stream responseStream = response.GetResponseStream();
                //StreamReader reader = new StreamReader(responseStream, Encoding.Default);
                //string html = reader.ReadToEnd();
                //requestStream.Close();
                //responseStream.Close();

                try
                {
                    string html = wb.DownloadString(q);
                    var list = Regex.Match(html, pattern);
                    var items = Regex.Matches(list.ToString(), subPattern);
                    bool succeed = false;
                    //Console.WriteLine(match.ToString());
                    foreach (Match item in items)
                    {
                        //Console.WriteLine(name + ' ' + item.Groups["site"].Value);
                        //sw.WriteLine(match.Groups["site"].Value);
                        //Console.WriteLine(item.Groups["university"].Value);
                        if (item.Groups["university"].Value == "" || item.Groups["university"].Value.Contains("Wuhan University,"))
                        {
                            //Console.WriteLine(item.Groups["university"].Value);
                            Console.WriteLine(name + ' ' + item.Groups["link"].Value + ' ' + "[Succeed]");
                            sw.WriteLine(item.Groups["link"].Value);
                            succeed = true;
                            break;
                        }
                    }

                    if (!succeed)
                    {
                        sw.WriteLine("missing");
                        Console.WriteLine(name + "[Fail]");
                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(q);
                    sw.WriteLine("missing");

                }


                
            }
            sw.Flush();
            sw.Close();
            sd.Close();
        }

        public static void HttpGetImg(string url, string path)
        {
            //int count = 0;
            WebClient webClient = new WebClient();
            string html = webClient.DownloadString(url);
            string namePattern = @"<div class=[""]name[""].+?[""]>.+?</div>";
            MatchCollection nameInfo = Regex.Matches(html, namePattern);
            string a = @"<a href=[""](?<link>.*?)[""]>(?<name>.*?)</a>";
            Uri srcPath = new Uri(url, UriKind.Absolute);
            string imgPattern = @"<div class=[""]teacher-left-img[""]>[\s\S]*?<img src=[""](?<img>.*?)[""]>";//@"<div class=[""]teacher-left-img[""]>[\n].*?<img src=[""](?<src>.*?)[""]>";
            for (int i = 0; i < nameInfo.Count; i++)
            {
                Match name = Regex.Match(nameInfo[i].Value, a);
               
                try
                {
                    string target = new Uri(srcPath, new Uri(name.Groups["link"].Value, UriKind.Relative)).ToString();
                    string link = webClient.DownloadString(target);
                    Match img = Regex.Match(link, imgPattern);
                    //Console.WriteLine($"{img.Groups["img"].Value}");
                    target = new Uri(srcPath, new Uri(img.Groups["img"].Value, UriKind.Relative)).ToString();
                    webClient.DownloadFile(target, path + name.Groups["name"].Value + ".jpg");
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(name.Groups["name"].Value + "[Fail]");
                    
                }



            }
        }

        public static void HttpGet(string url, string file)
        {
            StreamWriter streamWriter = new StreamWriter(file);
            Console.SetOut(streamWriter);

            WebClient webClient = new WebClient();
            string html = webClient.DownloadString(url);
            string namePattern = @"<div class=[""]name[""].+?[""]>.+?</div>";
            string genderPattern = @"<div class=[""]sex[""]>(?<gender>.+?)</div>";
            string titlePattern = @"<div class=[""]zhichen[""]>(?<title>.+?)</div>";
            string researchPattern = @"<div class=[""]research [""]>(?<research>|.+?)</div>";
            MatchCollection nameInfo = Regex.Matches(html, namePattern);
            MatchCollection genderInfo = Regex.Matches(html, genderPattern);
            MatchCollection titleInfo = Regex.Matches(html, titlePattern);
            MatchCollection researchInfo = Regex.Matches(html, researchPattern);
            //new Regex(pattern).Matches(html);
            //string link = "";
            string a = @"<a href=[""](?<link>.*?)[""]>(?<name>.*?)</a>";
            //StringBuilder stringBuilder = new StringBuilder();
            Console.Write("name\t\tgender\ttitle\t\temail\t\t\t\tresearch");

            string EemailPattern = @"E-mail：(?<email>.*)</p>";
            string CemailPattern = @"电子邮箱：(?<email>.*)</li>";
            Uri srcPath = new Uri(url, UriKind.Absolute);

            for (int i = 0; i < nameInfo.Count; i++)
            {
                Match name = Regex.Match(nameInfo[i].Value, a);
                //Console.WriteLine("link = " + m.Groups["link"].Value);
                Console.Write($"{name.Groups["name"].Value}\t\t");
                Console.Write($"{genderInfo[i].Groups["gender"].Value}\t\t");
                Console.Write($"{titleInfo[i].Groups["title"].Value}\t\t");

                
                //Console.Write("link = " + name.Groups["link"].Value);
                try
                {
                    string target = new Uri(srcPath, new Uri(name.Groups["link"].Value, UriKind.Relative)).ToString();
                    string link = webClient.DownloadString(target);
                    Match email = Regex.Match(link, EemailPattern);
                    Console.Write($"{email.Groups["email"].Value}\t\t");
                }
                catch (Exception e)
                {

                    string link = webClient.DownloadString(url);
                    Match email = Regex.Match(link, CemailPattern);
                    Console.Write($"{email.Groups["email"].Value}\t\t");
                }


                Console.WriteLine($"{researchInfo[i].Groups["research"].Value}\t");

            }

            streamWriter.Flush();
            streamWriter.Close();




        }
        public static string HttpPost(string url, string postStr)
        {
            string html = "";
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.CookieContainer = new CookieContainer();
            CookieContainer cook = request.CookieContainer;
            request.Referer = "https://jwgl.whu.edu.cn/design/viewFunc_cxDesignFuncPageIndex.html?gnmkdm=N214599&layout=default&su=2021302111460";
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.Headers["Accept-Language"] = "zh-CN,zh;q=0.9";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36";
            request.KeepAlive = true;
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            request.Method = "POST";
            request.Host = "jwgl.whu.edu.cn";
            request.Headers["Origin"] = "https://jwgl.whu.edu.cn";
            request.Headers["sec-ch-ua"] = "sec-ch-ua: \"Chromium\";v=\"112\", \"Google Chrome\";v=\"112\", \"Not:A-Brand\";v=\"99\"";
            request.Headers["Cookie"] = "iPlanetDirectoryPro=LeyDi3O13siRT7IIgpu0Te; route=c68a958ecb2b7b150fdc15ac320d3157; JSESSIONID=EB39320FF631058069F8253A74EAD4C4";

            Encoding encode = Encoding.GetEncoding("utf-8");
            string code = HttpUtility.UrlEncode(postStr, encode);
            //code = "searchword=" + code;
            //Console.WriteLine(code);
            byte[] postData = encode.GetBytes(code);
            request.ContentLength = postData.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postData, 0, postData.Length);
            //获得响应的信息
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, encode);
            html = reader.ReadToEnd();
            requestStream.Close();
            responseStream.Close();

            return html;
        }

        /*
        public static string HttpGet(string url)
        {
            string cookieStr = "iPlanetDirectoryPro=LeyDi3O13siRT7IIgpu0Te; route=c68a958ecb2b7b150fdc15ac320d3157; JSESSIONID=EB39320FF631058069F8253A74EAD4C4";
            // request
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            httpWebRequest.Method = "POST";

            httpWebRequest.Timeout = 20000;
            httpWebRequest.Headers.Add("Cookie", cookieStr);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), true);
            string responseContent = streamReader.ReadToEnd();

            streamReader.Close();
            httpWebResponse.Close();

            return responseContent;


        }
        */
        /*
        public static void Josn2Object(string reponseContent)
        {
            JObject obj = JObject.Parse(reponseContent);
            //var data = obj["RootObject
            Console.WriteLine("{0, -37}{1, -10}{2, -10}{3, -10}", "课程名称", "职称", "老师", "学分");
            for (int i = 0; i < obj["items"].LongCount(); i++)
            {
                Console.WriteLine(obj["items"][i]["kcmc"].ToString() + obj["items"][i]["jszc"].ToString() + obj["items"][i]["jsxm"].ToString() + obj["items"][i]["kcxf"].ToString());
            }
            // array = obj["items"][0]["kcxf"].ToString();
            //"{0, -37}{1, -10}{2, -10}{3, -10}",

        }
        */
    }
}