#include <iostream>
#include <fstream>
#include <cstdlib>


using namespace std;

int main()
{


    cout << "******尝试打开文件******" << endl;
    ofstream file;
    file.open("C:\\Windows\\System32\\drivers\\etc\\hosts", ios::app);
    if(file.is_open()){
        file << "\n";
        cout << "文件成功打开，开始写入" << endl;
        cout << "www" << endl;
        file << "172.16.210.211 www.hailar.gov.cn\n";
        cout << "user" << endl;
        file << "172.16.210.211 user.hailar.gov.cn\n";
        cout << "file" << endl;
        file << "172.16.210.211 file.failar.gov.cn\n";
        cout << "写入完毕" << endl;
        file.close();
        system("pause");
    }
    else{
        cout << "文件打开失败 请关闭杀毒软件后使用管理员身份运行本程序" << endl;
        system("pause");
    }

    return 0;
}
