//���������ɿƷ�EasyUi����������v3.5(build 20140519)��������������,��Ѱ��Զ����Ӱ�Ȩע��,�뱣����Ȩ��Ϣ�����������Ͷ��ɹ��������и��õĽ����뷢�����䣺843330160@qq.com
using System;
using System.Collections.Generic;

namespace RuRo.Model
{
   /// <summary>
   /// ʵ����Info
   /// </summary>
   public class Info
   {
       private int __id = 0;
       private string __���� = "";
       private string __���� = "";
       private string __�Ա� = "";
       private string __���� = "";
       private string __ҽ�� = "";
       private string __��ˮ�� = "";
       private string __���� = "";
       private string __סԺ�� = "";
       private string __������ = "";
       private string __��� = "";
       private string __���� = "";

       private Dictionary<string, bool> __Changed = new Dictionary<string, bool>();


       public Info()
       {
           this.__Changed.Add("id", false);
           this.__Changed.Add("����", false);
           this.__Changed.Add("����", false);
           this.__Changed.Add("�Ա�", false);
           this.__Changed.Add("����", false);
           this.__Changed.Add("ҽ��", false);
           this.__Changed.Add("��ˮ��", false);
           this.__Changed.Add("����", false);
           this.__Changed.Add("סԺ��", false);
           this.__Changed.Add("������", false);
           this.__Changed.Add("���", false);
           this.__Changed.Add("����", false);
       }

       /// <summary>
       /// �������õ���ʼ��״̬
       /// </summary>
       public void Reset()
       {
           this.__id = 0;
           this.__���� = "";
           this.__���� = "";
           this.__�Ա� = "";
           this.__���� = "";
           this.__ҽ�� = "";
           this.__��ˮ�� = "";
           this.__���� = "";
           this.__סԺ�� = "";
           this.__������ = "";
           this.__��� = "";
           this.__���� = "";

           this.__Changed["id"] = false;
           this.__Changed["����"] = false;
           this.__Changed["����"] = false;
           this.__Changed["�Ա�"] = false;
           this.__Changed["����"] = false;
           this.__Changed["ҽ��"] = false;
           this.__Changed["��ˮ��"] = false;
           this.__Changed["����"] = false;
           this.__Changed["סԺ��"] = false;
           this.__Changed["������"] = false;
           this.__Changed["���"] = false;
           this.__Changed["����"] = false;
       }

       /// <summary>
       /// ��ȡ���г�Ա�ĸı�״̬
       /// </summary>
       public bool Changed(string strKey)
       {
           return __Changed[strKey];
       }



       /// <summary>
       /// ���û��ȡ���е�[id]������
       /// </summary>
       public int id
       {
           set{ __id = value; __Changed["id"] = true;}
           get{return __id;}
       }

       /// <summary>
       /// ���û��ȡ���е�[����]������
       /// </summary>
       public string ����
       {
           set{ __���� = value; __Changed["����"] = true;}
           get{return __����;}
       }

       /// <summary>
       /// ���û��ȡ���е�[����]������
       /// </summary>
       public string ����
       {
           set{ __���� = value; __Changed["����"] = true;}
           get{return __����;}
       }

       /// <summary>
       /// ���û��ȡ���е�[�Ա�]������
       /// </summary>
       public string �Ա�
       {
           set{ __�Ա� = value; __Changed["�Ա�"] = true;}
           get{return __�Ա�;}
       }

       /// <summary>
       /// ���û��ȡ���е�[����]������
       /// </summary>
       public string ����
       {
           set{ __���� = value; __Changed["����"] = true;}
           get{return __����;}
       }

       /// <summary>
       /// ���û��ȡ���е�[ҽ��]������
       /// </summary>
       public string ҽ��
       {
           set{ __ҽ�� = value; __Changed["ҽ��"] = true;}
           get{return __ҽ��;}
       }

       /// <summary>
       /// ���û��ȡ���е�[��ˮ��]������
       /// </summary>
       public string ��ˮ��
       {
           set{ __��ˮ�� = value; __Changed["��ˮ��"] = true;}
           get{return __��ˮ��;}
       }

       /// <summary>
       /// ���û��ȡ���е�[����]������
       /// </summary>
       public string ����
       {
           set{ __���� = value; __Changed["����"] = true;}
           get{return __����;}
       }

       /// <summary>
       /// ���û��ȡ���е�[סԺ��]������
       /// </summary>
       public string סԺ��
       {
           set{ __סԺ�� = value; __Changed["סԺ��"] = true;}
           get{return __סԺ��;}
       }

       /// <summary>
       /// ���û��ȡ���е�[������]������
       /// </summary>
       public string ������
       {
           set{ __������ = value; __Changed["������"] = true;}
           get{return __������;}
       }

       /// <summary>
       /// ���û��ȡ���е�[���]������
       /// </summary>
       public string ���
       {
           set{ __��� = value; __Changed["���"] = true;}
           get{return __���;}
       }

       /// <summary>
       /// ���û��ȡ���е�[����]������
       /// </summary>
       public string ����
       {
           set{ __���� = value; __Changed["����"] = true;}
           get{return __����;}
       }

   }
}
