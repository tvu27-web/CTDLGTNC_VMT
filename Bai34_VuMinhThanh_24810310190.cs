#include <stdio.h>
#include <string.h>

// Cau truc Ngay sinh
struct NgaySinh
{
    int ngay;
    int thang;
    int nam;
};

// Cau truc Nhan vien
struct NhanVien
{
    int maNV;
    char hoTen[50];
    NgaySinh ns;
    float luong;
};

// Cau 2: Ham nhap
void Nhap(NhanVien a[], int n)
{
    for (int i = 0; i < n; i++)
    {
        printf("\nNhap nhan vien thu %d:\n", i + 1);

        printf("Ma nhan vien: ");
        scanf("%d", &a[i].maNV);

        fflush(stdin);
        printf("Ho ten: ");
        gets(a[i].hoTen);

        printf("Ngay sinh:\n");

        printf("  Ngay: ");
        scanf("%d", &a[i].ns.ngay);

        printf("  Thang: ");
        scanf("%d", &a[i].ns.thang);

        printf("  Nam: ");
        scanf("%d", &a[i].ns.nam);

        printf("Luong (trieu dong): ");
        scanf("%f", &a[i].luong);
    }
}

// Cau 3: Ham xuat
void Xuat(NhanVien a[], int n)
{
    printf("\n%-10s %-25s %-15s %-15s\n",
           "Ma NV", "Ho ten", "Ngay sinh", "Luong");

    for (int i = 0; i < n; i++)
    {
        printf("%-10d %-25s %02d/%02d/%-8d %-15.2f\n",
               a[i].maNV,
               a[i].hoTen,
               a[i].ns.ngay,
               a[i].ns.thang,
               a[i].ns.nam,
               a[i].luong);
    }
}

// Cau 4: Sap xep noi bot
void BubbleSort(NhanVien a[], int n)
{
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - 1 - i; j++)
        {
            if (a[j].luong > a[j + 1].luong)
            {
                NhanVien temp = a[j];
                a[j] = a[j + 1];
                a[j + 1] = temp;
            }
        }
    }
}

// Cau 5: Tim kiem nhi phan
void TimKiemNhiPhan(NhanVien a[], int n, float X)
{
    int left = 0;
    int right = n - 1;
    int found = 0;

    while (left <= right)
    {
        int mid = (left + right) / 2;

        if (a[mid].luong == X)
        {
            // Tim phan tu dau tien co luong = X
            int i = mid;

            while (i >= 0 && a[i].luong == X)
            {
                i--;
            }

            i++;

            // Xuat tat ca nhan vien co luong = X
            while (i < n && a[i].luong == X)
            {
                printf("%-10d %-25s %02d/%02d/%-8d %-15.2f\n",
                       a[i].maNV,
                       a[i].hoTen,
                       a[i].ns.ngay,
                       a[i].ns.thang,
                       a[i].ns.nam,
                       a[i].luong);

                found = 1;
                i++;
            }

            break;
        }
        else if (a[mid].luong < X)
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
        printf("\nKhong tim thay nhan vien co luong = %.2f trieu dong!\n", X);
    }
}

// Cau 6: Ham main
int main()
{
    NhanVien a[100];
    int n;
    float X;

    printf("Nhap so luong nhan vien n = ");
    scanf("%d", &n);

    // Nhap
    Nhap(a, n);

    // Xuat danh sach vua nhap
    printf("\n========== DANH SACH NHAN VIEN VUA NHAP ==========\n");
    Xuat(a, n);

    // Sap xep
    BubbleSort(a, n);

    printf("\n========== DANH SACH SAU KHI SAP XEP ==========\n");
    Xuat(a, n);

    // Tim kiem
    printf("\nNhap luong can tim X = ");
    scanf("%f", &X);

    printf("\n========== NHAN VIEN CO LUONG = %.2f ==========\n", X);
    TimKiemNhiPhan(a, n, X);

    return 0;
}
