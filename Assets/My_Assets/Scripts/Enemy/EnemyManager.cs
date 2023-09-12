//using system.collections;
//using system.collections.generic;
//using unityengine;
//using unityengine.uielements;
//using system.io;
//using UnityEngine;

//public class enemymanager : monobehaviour
//{
//    [serializefield] private int enemyslistlength = 20;
//    [serializefield] private int enemymlistlength = 10;
//    [serializefield] private int enemyllistlength = 5;
//    [serializefield] private gameobject enemys; //_enemys
//    [serializefield] private gameobject enemym; //_enemym
//    [serializefield] private gameobject enemyl; //_enemyl
//    list<gameobject> enemyslist = new list<gameobject>();
//    list<gameobject> enemymlist = new list<gameobject>();
//    list<gameobject> enemyllist = new list<gameobject>(); // 풀링용 리스트
//    [serializefield] private gameobject[] spawnpoints;    // 스폰 포인트 배열

//    list<enemyspawn> enemyspawnlist = new list<enemyspawn>();  // 텍스트파일 읽어온 정보 저장용 리스트

//    public gameobject enemytospawn;

//    enemyspawn enemyspawndata;

//    private bool spawnend = true;

//    private void start()
//    {
//        pullingenemys();
//        pullingenemym();
//        pullingenemyl();

//        readspawnfile();

//        spawnenemy();
//    }

//    private void update()
//    {

//    }

//    private void pullingenemys()
//    {
//        for (int i = 0; i < enemyslistlength; i++)
//        {
//            gameobject _enemys = instantiate(enemys);
//            enemyslist.add(_enemys);

//            _enemys.setactive(false);

//            _enemys.transform.parent = transform;

//            debug.log("풀링 완료");
//        }
//    }

//    private void pullingenemym()
//    {
//        for (int i = 0; i < enemymlistlength; i++)
//        {
//            gameobject _enemym = instantiate(enemym);
//            enemymlist.add(_enemym);

//            _enemym.setactive(false);

//            _enemym.transform.parent = transform;
//        }
//    }

//    private void pullingenemyl()
//    {
//        for (int i = 0; i < enemyllistlength; i++)
//        {
//            GameObject _enemyl = Instantiate(enemyl);
//            enemyllist.add(_enemyl);

//            _enemyl.setactive(false);

//            _enemyl.transform.parent = transform;
//        }
//    }

//    private gameobject getinactiveenemy(list<gameobject> enemylist)
//    {
//        foreach (gameobject enemy in enemylist)
//        {
//            if (!enemy.activeself)
//            {
//                debug.log("풀링 활성화");
//                return enemy;
//            }
//        }
//        return null;
//    }

//    private void readspawnfile()
//    {
//        textasset stage1 = resources.load("stage 1") as textasset;
//        stringreader stringreader = new stringreader(stage1.text);

//        while (stringreader != null)
//        {
//            string line = stringreader.readline();

//            if (line == null)
//                break;

//            enemyspawn es = new enemyspawn();

//            es.spawntime = float.parse(line.split(',')[0]); //스폰 시간 float
//            es.enemytype = line.split(',')[1];              //적 유형 string
//            es.spawnpoint = int.parse(line.split(',')[2]);  //스폰포인트 int

//            debug.log("시간" + es.spawntime);
//            debug.log("유형" + es.enemytype);
//            debug.log("위치" + es.spawnpoint);

//            enemyspawnlist.add(enemyspawndata);
//            debug.log(enemyspawndata);
//        }
//        stringreader.close();
//    }

//    public void spawnenemy()
//    {
//        while (spawnend)
//        {
//            debug.log(spawnend); //11번 돈다
//            switch (enemyspawndata.enemytype)
//            {
//                case "s":
//                    enemytospawn = getinactiveenemy(enemyslist); //10번 활성화 txt파일은 8줄
//                    debug.log("s 소환");
//                    break;
//                case "m":
//                    enemytospawn = getinactiveenemy(enemymlist);
//                    debug.log("m 소환");
//                    break;
//                case "l":
//                    enemytospawn = getinactiveenemy(enemyllist);
//                    debug.log("l 소환");
//                    break;
//            }
//            if (enemytospawn != null)
//            {
//                gameobject spawnpoint = spawnpoints[enemyspawndata.spawnpoint - 1];
//                enemytospawn.transform.position = spawnpoint.transform.position;
//                enemytospawn.setactive(true);
//            }
//            else
//            {
//                spawnend = false;
//                debug.log(spawnend);
//            }
//        }
//    }
//}



