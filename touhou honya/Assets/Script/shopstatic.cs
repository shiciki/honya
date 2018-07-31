using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class shopstatic : MonoBehaviour {
    public static int ABNUM = 5;  //书籍属性种类数
    public static int TAGNUM = 8; //书籍标签种类数
    public static int THEMENUM = 8; //主题种类数，随机用
    //public class CustomOnShop;
    //public CustomOnShop BooklistOnshop[];
    //public BookOnShop CustomlistOnshop[];
    //puclic class decorate;
    

    public class BookOnShop
    {
        public string tittle;    //名称
        public int Page;
        public int BookDuration; //书本耐久 损坏20破损50陈旧80瑕疵90崭新100
        public int BookQuality; //书本材质  0纸张 1竹卷 2羊皮纸 3帛书 4血书 5版牍（木制） 6kindle(极少)
        public int Bookclean;   // 0干净 1落灰 2肮脏 3无法处理的污渍，可大于3 n*10%拒绝租借
        public int BookcontenID; // 内容ID，除非抄本和特殊时间否则不重复
        public int[] AbilityChange = new int[ABNUM]; //能力变化 野望，狂气，san值，战力，色气{yabou,qiuki,san,senri,ero}
        public bool[] Tag = new bool[TAGNUM];//精装，绘本，封印，仪式，召唤，源起，念写，仪式 
        public int Theme;        // 书籍主题 如科技，魔法
        public int Copyed;      //是否为抄本
        public int SummonedAblity;//被召唤生物能力
        public int Skill;         //技能函数类别 0为无技能 
        public int rare;//普通，稀有，史诗，传说
        public string story;
        public int personID;//持有者 小于0在商店，等于0在店内未借出 大于0借给对应ID顾客

    }


    public class GlobalData//游戏全局数据
    {
         public int MAXBookcontenID; //已获得书籍内容数
         public int MAXBookID;       //最大书本数
         public int Day;
        public int Gold;
        public List<BookOnShop> bookdata = new List<BookOnShop>();
        //单例模式全局数据
        private static GlobalData _data;

        public static GlobalData CreateData()
        {
            if (_data == null)
            {
                _data = new GlobalData();
            }
            return _data;
        }


        public void newgamedata() //初始化游戏数据
        {
            GlobalData Gamedata = GlobalData.CreateData();
            Gamedata.MAXBookcontenID = 0;
            Gamedata.MAXBookID = 0;
        }

        public void AddBookData(int copyID = 0)
        {
            GlobalData Gamedata = GlobalData.CreateData();
            if ( copyID == 0)
            {
                Gamedata.MAXBookcontenID++;
                Gamedata.MAXBookID++;
            }
            else
            {
                Gamedata.MAXBookID++;
            }
        }
    }

    // Use this for initialization
    private void Awake()
    {
        intiGame();
    }
 
	void Start () {
        //切换场景不销毁数据
        GameObject.DontDestroyOnLoad(gameObject);


        GlobalData Gamedata = GlobalData.CreateData();

        //初始金钱 可用于难度调整
        Gamedata.Gold = Random.Range(50, 150);
        //初始书籍列表

        for (int i = 0; i < 10; i++)
        {
            Gamedata.bookdata.Add(bookgenrate(0));
        }
    }
	
	// Update is called once per frame
	void Update () {

    }

    void intiGame()
    {
        //初始化全局数据 Gamedata
        GlobalData Gamedata = GlobalData.CreateData();
        Gamedata.newgamedata();
    }

    public BookOnShop bookgenrate(int copyID=0) //参数，是否为创建抄本
    {
        BookOnShop Book =new BookOnShop();
        GlobalData Gamedata = GlobalData.CreateData();


        Book.tittle = "1"; //书本标题，后续使用文件列表读取预定书名

        //书本页数
        int Minpage = 50;
        int Maxpage = 200;
        Book.Page = Random.Range(Minpage, Maxpage);

        //书本耐久， 后续根据难度调整上下限     损坏20破损50陈旧80瑕疵90崭新100
        Book.BookDuration = Random.Range(20, 100);

        //书本材质 0纸张 1竹卷 2羊皮纸 3帛书 4血书 5版牍（木制） 6kindle(极少)
        if(Random.Range(0,100000) ==1)
            Book.BookQuality = 6;
        else
            Book.BookQuality = Random.Range(0, 5);

        // 0干净 1落灰 2肮脏 3无法处理的污渍，可大于3 n*10%拒绝租借 根据店内整洁程度随机落灰 租借后有几率变脏
        Book.Bookclean =0;

        // 内容ID，除非抄本和特殊时间否则不重复
        if (copyID == 0)
        {
            Gamedata.AddBookData();
            Book.BookcontenID = Gamedata.MAXBookcontenID;
        }
        else
        {
            Book.BookcontenID = copyID;
            Gamedata.AddBookData(copyID);
        }

        //能力变化 野望，狂气，san值，战力，色气{yabou,qiuki,san,senri,ero}
        float ability = Random.Range(1, 100);
        if (ability >= 90)
            Book.AbilityChange[0] = Random.Range(5, 10);
        else if (ability < 30)
            Book.AbilityChange[0] = Random.Range(-3, 5);
        else
            Book.AbilityChange[0] = 0;

        ability = Random.Range(1, 100);
        if (ability >= 90)
            Book.AbilityChange[1] = Random.Range(5, 10);
        else if (ability < 30)
            Book.AbilityChange[1] = Random.Range(-3, 5);
        else
            Book.AbilityChange[1] = 0;

        ability = Random.Range(1, 100);
        if (ability >= 90)
            Book.AbilityChange[2] = Random.Range(-5, 0);
        else
            Book.AbilityChange[2] = 0;

        ability = Random.Range(1, 100);
        if (ability >= 90)
            Book.AbilityChange[3] = Random.Range(5, 10);
        else if (ability < 30)
            Book.AbilityChange[3] = Random.Range(-3, 5);
        else
            Book.AbilityChange[3] = 0;

        ability = Random.Range(1, 100);
        if (ability >= 90)
            Book.AbilityChange[4] = Random.Range(5, 0);
        else
            Book.AbilityChange[4] = 0;



        bool[] Tag = new bool[TAGNUM];//精装，绘本，封印，召唤，源起，念写
        ability = Random.Range(1, 100);
        if (ability >= 80)
            Book.Tag[0] = true;
        else
            Book.Tag[0] = false;

        ability = Random.Range(1, 100);
        if (ability >= 95)
            Book.Tag[1] = true;
        else
            Book.Tag[1] = false;

            Book.Tag[2] = false;

        ability = Random.Range(1, 100);
        if (ability >= 95)
            Book.Tag[3] = true;
        else
            Book.Tag[3] = false;

        ability = Random.Range(1, 100);
        if (ability >= 80)
            Book.Tag[4] = true;
        else
            Book.Tag[4] = false;

        ability = Random.Range(1, 100);
        if (ability >= 99)
            Book.Tag[5] = true;
        else
            Book.Tag[5] = false;


        int Theme= Random.Range(1, 5); ;        // 书籍主题 如科技，魔法

        //是否为抄本
        if (copyID == null || copyID == 0)
        {
            Book.Copyed = 0; ;
        }
        else
        {
            Book.Copyed=copyID;
        }


        int SummonedAblity;//被召唤生物能力
        Book.SummonedAblity = Random.Range(1, 100);

        ability = Random.Range(1, 100);
        if (ability >= 90)
            Book.Skill = Random.Range(5, 0);
        else
            Book.Skill = 0;

        //源起应该指向目标类（如人物，事件的描述字段）
        Book.story = "一本平凡无奇的书";
        Book.personID = 0;

        return Book;
    }
}