#include <iostream>
#include <fstream>
#include <cstdlib>


using namespace std;

int main()
{


    cout << "******���Դ��ļ�******" << endl;
    ofstream file;
    file.open("C:\\Windows\\System32\\drivers\\etc\\hosts", ios::app);
    if(file.is_open()){
        file << "\n";
        cout << "�ļ��ɹ��򿪣���ʼд��" << endl;
        cout << "www" << endl;
        file << "172.16.210.211 www.hailar.gov.cn\n";
        cout << "user" << endl;
        file << "172.16.210.211 user.hailar.gov.cn\n";
        cout << "file" << endl;
        file << "172.16.210.211 file.failar.gov.cn\n";
        cout << "д�����" << endl;
        file.close();
        system("pause");
    }
    else{
        cout << "�ļ���ʧ�� ��ر�ɱ�������ʹ�ù���Ա������б�����" << endl;
        system("pause");
    }

    return 0;
}
