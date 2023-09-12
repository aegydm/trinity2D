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
//    list<gameobject> enemyllist = new list<gameobject>(); // Ǯ���� ����Ʈ
//    [serializefield] private gameobject[] spawnpoints;    // ���� ����Ʈ �迭

//    list<enemyspawn> enemyspawnlist = new list<enemyspawn>();  // �ؽ�Ʈ���� �о�� ���� ����� ����Ʈ

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

//            debug.log("Ǯ�� �Ϸ�");
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
//                debug.log("Ǯ�� Ȱ��ȭ");
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

//            es.spawntime = float.parse(line.split(',')[0]); //���� �ð� float
//            es.enemytype = line.split(',')[1];              //�� ���� string
//            es.spawnpoint = int.parse(line.split(',')[2]);  //��������Ʈ int

//            debug.log("�ð�" + es.spawntime);
//            debug.log("����" + es.enemytype);
//            debug.log("��ġ" + es.spawnpoint);

//            enemyspawnlist.add(enemyspawndata);
//            debug.log(enemyspawndata);
//        }
//        stringreader.close();
//    }

//    public void spawnenemy()
//    {
//        while (spawnend)
//        {
//            debug.log(spawnend); //11�� ����
//            switch (enemyspawndata.enemytype)
//            {
//                case "s":
//                    enemytospawn = getinactiveenemy(enemyslist); //10�� Ȱ��ȭ txt������ 8��
//                    debug.log("s ��ȯ");
//                    break;
//                case "m":
//                    enemytospawn = getinactiveenemy(enemymlist);
//                    debug.log("m ��ȯ");
//                    break;
//                case "l":
//                    enemytospawn = getinactiveenemy(enemyllist);
//                    debug.log("l ��ȯ");
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



