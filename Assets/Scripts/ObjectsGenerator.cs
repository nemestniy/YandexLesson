using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsGenerator : MonoBehaviour
{
    public GameObject Prefab;

    [Space(10)]

    [Header("Array generation settings:")]
    public Vector2 Bounds;
    public float Space = 2.0f;

    [Space(10)]

    //Генерировать ли в формате шахматной доски
    public bool GenerateAsChess = false;

    private void Start()
    {
        //Проверка, лежит ли что то в переменной Prefab
        if (Prefab) 
        {
            //Здесь цикл внутри цикла
            //Для граничных занчений используются две координаты Vector2
            //Внутри второго цикла далее следует нужная логика, в данном случае, генерация объекта
            //Можно прописать свою какую либо логику в зависимости от координат, например, как тут, генерация по шахматной доске
            for (int i = 0; i < Bounds.x; i++)
            {
                for (int j = 0; j < Bounds.y; j++)
                {
                    if (!GenerateAsChess)
                    {
                        GenerateObject(i, j);
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            if (j % 2 == 1)
                            {
                                GenerateObject(i, j);
                            }
                        }
                        else
                        {
                            if (j % 2 == 0)
                            {
                                GenerateObject(i, j);
                            }
                        }
                    }
                }
            }
        }
    }

    private void GenerateObject(int x, int y)
    {
        Vector3 position = new Vector3(x * Space, 0.0f, y * Space);
        var newObject = Instantiate(Prefab, transform);
        newObject.transform.position = position;
        newObject.transform.rotation = Quaternion.identity;
    }

}
