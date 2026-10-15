#include <iostream>
#include <fstream>
#include <iomanip>
using namespace std;

const int MAX = 20;

bool Nhap(const char* tenFile, int A[MAX][MAX], int &n)
{
    ifstream f(tenFile);
    if (!f.is_open())
    {
        cout << "Khong mo duoc file " << tenFile << endl;
        return false;
    }
    f >> n;
    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
            f >> A[i][j];
    f.close();
    return true;
}

void HienThi(int A[MAX][MAX], int n)
{
    cout << "Ma tran trong so cua do thi:" << endl;
    cout << setw(4) << " ";
    for (int j = 0; j < n; j++)
        cout << setw(4) << char('A' + j);
    cout << endl;
    for (int i = 0; i < n; i++)
    {
        cout << setw(4) << char('A' + i);
        for (int j = 0; j < n; j++)
            cout << setw(4) << A[i][j];
        cout << endl;
    }
}

int main()
{
    int A[MAX][MAX];
    int n;
    if (Nhap("Grap.txt", A, n))
        HienThi(A, n);
    return 0;
}
