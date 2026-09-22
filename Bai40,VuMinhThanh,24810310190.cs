#include <iostream>
#include <iomanip>
#include <cstring>

using namespace std;

// =========================
// cau truc sinh vien
// =========================
struct SinhVien
{
    int maSV;
    char tenSV[50];
    char lop[20];
    float tongKet;
    char hanhKiem[20];
};

// =========================
// cau truc node
// =========================
struct Node
{
    SinhVien data;
    Node *left;
    Node *right;
};

typedef Node *Tree;

// =========================
// khoi tao cay
// =========================
void KhoiTao(Tree &T)
{
    T = NULL;
}

// =========================
// nhap sinh vien
// =========================
void NhapSV(SinhVien &sv)
{
    cout << "Nhap ma sinh vien: ";
    cin >> sv.maSV;

    cin.ignore();

    cout << "Nhap ten sinh vien: ";
    cin.getline(sv.tenSV, 50);

    cout << "Nhap lop: ";
    cin.getline(sv.lop, 20);

    cout << "Nhap tong ket: ";
    cin >> sv.tongKet;

    cin.ignore();

    cout << "Nhap hanh kiem: ";
    cin.getline(sv.hanhKiem, 20);
}

// =========================
// xuat sinh vien
// =========================
void XuatSV(SinhVien sv)
{
    cout << left
         << setw(10) << sv.maSV
         << setw(25) << sv.tenSV
         << setw(15) << sv.lop
         << setw(10) << sv.tongKet
         << setw(15) << sv.hanhKiem
         << endl;
}

// =========================
// tao node
// =========================
Node *TaoNode(SinhVien sv)
{
    Node *p = new Node;

    p->data = sv;
    p->left = NULL;
    p->right = NULL;

    return p;
}

// =========================
// chen node vao cay
// =========================
void ChenNode(Tree &T, Node *p)
{
    if (T == NULL)
    {
        T = p;
    }
    else
    {
        if (p->data.maSV < T->data.maSV)
        {
            ChenNode(T->left, p);
        }
        else if (p->data.maSV > T->data.maSV)
        {
            ChenNode(T->right, p);
        }
    }
}

// =========================
// tim kiem
// =========================
Node *TimKiem(Tree T, int ma)
{
    if (T == NULL)
    {
        return NULL;
    }

    if (ma == T->data.maSV)
    {
        return T;
    }

    if (ma < T->data.maSV)
    {
        return TimKiem(T->left, ma);
    }
    else
    {
        return TimKiem(T->right, ma);
    }
}

// =========================
// duyet cay lnr
// =========================
void DuyetCay(Tree T)
{
    if (T != NULL)
    {
        DuyetCay(T->left);

        XuatSV(T->data);

        DuyetCay(T->right);
    }
}

// =========================
// main
// =========================
int main()
{
    Tree T;

    // Câu 3 khoi tao cay
    KhoiTao(T);

    int n;

    cout << "Nhap so luong sinh vien: ";
    cin >> n;

    // nhap n sinh vien
    for (int i = 0; i < n; i++)
    {
        SinhVien sv;

        cout << "\nNhap sinh vien thu " << i + 1 << ":\n";

        NhapSV(sv);

        Node *p = TaoNode(sv);

        ChenNode(T, p);
    }

    // cau 4 duyet cay
    cout << "\n==============================================";
    cout << "\nDANH SACH SINH VIEN TRONG CAY";
    cout << "\n==============================================\n";

    cout << left
         << setw(10) << "Ma SV"
         << setw(25) << "Ten SV"
         << setw(15) << "Lop"
         << setw(10) << "Tong ket"
         << setw(15) << "Hanh kiem"
         << endl;

    DuyetCay(T);

    // cau 5 tim kiem
    int ma;

    cout << "\nNhap ma sinh vien can tim: ";
    cin >> ma;

    Node *p = TimKiem(T, ma);

    if (p != NULL)
    {
        cout << "\nTim thay sinh vien:\n";

        cout << left
             << setw(10) << "Ma SV"
             << setw(25) << "Ten SV"
             << setw(15) << "Lop"
             << setw(10) << "Tong ket"
             << setw(15) << "Hanh kiem"
             << endl;

        XuatSV(p->data);
    }
    else
    {
        cout << "\nKhong co sinh vien trong cay!";
    }

    return 0;
}
