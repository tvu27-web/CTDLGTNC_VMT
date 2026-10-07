#include <stdio.h>
#include <string.h>

// Cau 1: Dinh nghia cau truc Khach hang
struct KhachHang
{
    int maKH;
    char tenKH[50];
    char sdt[15];
    float tongTien;
};

// Cau 2: Ham nhap mang n khach hang
void Nhap(KhachHang a[], int n)
{
    for (int i = 0; i < n; i++)
    {
        printf("\nNhap khach hang thu %d:\n", i + 1);

        printf("Ma khach hang: ");
        scanf("%d", &a[i].maKH);

        fflush(stdin);
        printf("Ten khach hang: ");
        gets(a[i].tenKH);

        printf("So dien thoai: ");
        gets(a[i].sdt);

        printf("Tong tien thanh toan: ");
        scanf("%f", &a[i].tongTien);
    }
}

// Cau 3: Ham xuat mang n khach hang
void Xuat(KhachHang a[], int n)
{
    printf("\n%-10s %-25s %-15s %-15s\n",
           "Ma KH", "Ten KH", "So DT", "Tong tien");

    for (int i = 0; i < n; i++)
    {
        printf("%-10d %-25s %-15s %-15.2f\n",
               a[i].maKH,
               a[i].tenKH,
               a[i].sdt,
               a[i].tongTien);
    }
}

// Cau 4: Sap xep chen truc tiep
void InsertionSort(KhachHang a[], int n)
{
    for (int i = 1; i < n; i++)
    {
        KhachHang x = a[i];
        int pos = i - 1;

        while (pos >= 0 && a[pos].tongTien > x.tongTien)
        {
            a[pos + 1] = a[pos];
            pos--;
        }

        a[pos + 1] = x;
    }
}

// Cau 5: Tim kiem nhi phan khach hang co tong tien bang X
void TimKiemNhiPhan(KhachHang a[], int n, float X)
{
    int left = 0;
    int right = n - 1;
    int found = 0;

    while (left <= right)
    {
        int mid = (left + right) / 2;

        if (a[mid].tongTien == X)
        {
            // Tim duoc 1 khach hang
            // Tim sang trai de tim cac khach hang trung X
            int i = mid;

            while (i >= 0 && a[i].tongTien == X)
            {
                i--;
            }

            i++;

            // Tim sang phai
            while (i < n && a[i].tongTien == X)
            {
                printf("%-10d %-25s %-15s %-15.2f\n",
                       a[i].maKH,
                       a[i].tenKH,
                       a[i].sdt,
                       a[i].tongTien);

                found = 1;
                i++;
            }

            break;
        }
        else if (a[mid].tongTien < X)
        {
            left = mid + 1;
        }
        else
        {
            right = mid - 1;
        }
    }

    if (found == 0)
    {
        printf("\nKhong tim thay khach hang co tong tien = %.2f", X);
    }
}

// Cau 6: Ham main
int main()
{
    KhachHang a[100];
    int n;
    float X;

    // Nhap n
    printf("Nhap so luong khach hang n = ");
    scanf("%d", &n);

    // Nhap mang
    Nhap(a, n);

    // Xuat mang vua nhap
    printf("\n===== DANH SACH KHACH HANG VUA NHAP =====\n");
    Xuat(a, n);

    // Sap xep
    InsertionSort(a, n);

    // Xuat mang sau khi sap xep
    printf("\n===== DANH SACH SAU KHI SAP XEP =====\n");
    Xuat(a, n);

    // Nhap X
    printf("\nNhap tong tien can tim X = ");
    scanf("%f", &X);

    // Tim kiem nhi phan
    printf("\n===== KHACH HANG CO TONG TIEN = %.2f =====\n", X);

    TimKiemNhiPhan(a, n, X);

    return 0;
}
