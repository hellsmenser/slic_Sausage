using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballistica : MonoBehaviour
{
    private LineRenderer LineRendererComponent;
    void Start()
    {
        LineRendererComponent = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 origin, Vector3 speed)
    {   //������� ������ �����
        Vector3[] points = new Vector3[100];
        LineRendererComponent.positionCount = points.Length;

        for(int i = 0; i < points.Length; i++)
        {//��� ������ ����� ����������� ��������� �� �������
            float time = i * 0.1f;
            points[i] = origin + speed * time + Physics.gravity * time * time / 2;

            if(points[i].y < 0)
            {//������� ������ �����
                LineRendererComponent.positionCount = i;
                break;
            }
        }
        //������������� ��������� �����
        LineRendererComponent.SetPositions(points);
    }


    public void ClearTrajectory()
    {//�������� �����
        LineRendererComponent.positionCount = 0;
    }
}
