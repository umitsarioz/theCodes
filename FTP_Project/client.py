import os
from ftplib import FTP, all_errors
import time

username = 'umit'
password = '141180059'
ftp = FTP()
def login(username,pw):
    try:
        host_id = 'localhost'
        port_id = 1080
        ftp.connect(host_id,port_id)
        if username.strip() == '' or pw.strip() == '':
            ftp.login()
            print("Ananoymous hg")
        else:
            ftp.login(username, password)
            print(f"{username} hg")
        print(ftp.getwelcome())
    except Exception as e:
        print("Hata : " + str(e))
        print('Hata ', 'Yanlış kullanıcı adı/parola veya geçersiz sunucu bağlantı bilgileri !\n\nError\n\nIncorrect username/password or invalid user connection information !')

def upload(sending_file,will_upload_file):
    try:
        reading_file = open(sending_file, 'rb')
    except Exception as e:
        print("Kaynak dosya okunurken hata!Exp:",e)
    try:
        ftp.storbinary('STOR '+will_upload_file,reading_file )
        print("Dosya başarıyla upload edildi..")
    except Exception as e:
        print("Upload Error!Exp:",e)

def download(destination,source):
    try:
        dosya = open(destination, 'wb')
        print("Hedef dosya oluşturuldu..")
    except Exception as e :
        print("Hedef dosya oluşturulurken hata!Exp:",e)
    try:
        ftp.retrbinary('RETR ' + source, dosya.write, 1024)
        print("Dosya başarıyla indirildi..")
    except Exception as e:
        print("Dosya indirilirken hata!Exp:",e)

    ftp.quit()
    dosya.close()

def createDirectory(dizin_adi):
    try:
        ftp.mkd(dizin_adi)
        print("Dizin başarıyla oluşturuldu..")
    except Exception as e:
        print("Dizin zaten mevcut.")

def deleteDirectory(dizin_adi):
    try:
        ftp.rmd(dizin_adi)
    except Exception as e:
        print("Dizin silinemedi!Exp:",e)

def rename(old_name, new_name):
    try:
        ftp.rename(old_name, new_name)
        print("Dosya ismi değiştirildi..")
    except Exception as e:
        print("Aynı isimde dosya zaten bulunuyor.Hata Açıklaması:",e)

def listDirectoryOnRemote(directory):
    try:
        files = ftp.nlst(directory)
        for file in files:
            print(file)
        print("Uzak bilgisayardaki dosyalar listeleniyor..")
    except Exception as e :
        print("Uzak bilgisayardaki dosyalar listelenemiyor..Açıklama:",e)
def listDirectoryOnLocal(directory):
    try:
        for file in os.listdir(directory):
            print(file)
        print("Lokaldeki dosyalar listeleniyor..")
    except Exception as e :
        print("Lokaldeki Dosyalar listelenemiyor.. Açıklama:",e)
## Bağlantı sağlama
login(username,password)
### Dosya upload etme
sending_file = './Local/sending_file1.txt'  # üklenecek dosya adı
will_upload_file = './uploaded.txt'
#upload(sending_file,will_upload_file)
print(f"{sending_file} dosyasi okunuyor, {will_upload_file} olarak kaydediliyor")
source = 'source.txt'
destination = './Local/indirilen_dosya.txt'
time.sleep(3)
print(f"{destination} dosyası {destination}'a indiriliyor..")
#download(destination,source)

yenidosya = './umit_yeni'
eski_dosya = yenidosya
renamed_dosya = './umit_renamed'
print(f"{yenidosya} oluşturuldu")
time.sleep(1)
createDirectory(yenidosya)
time.sleep(1)
print(f"{eski_dosya} --> {renamed_dosya} oldu.")
time.sleep(1)
rename(eski_dosya,renamed_dosya)
time.sleep(1)
print(f"{renamed_dosya} silindi..")
time.sleep(1)
deleteDirectory(renamed_dosya)
time.sleep(1)
print("LOKAL FILES")
time.sleep(1)
listDirectoryOnLocal('.')
time.sleep(1)
current_remote_path =  ftp.cwd('.')
print("Current server path:",current_remote_path)
time.sleep(1)
print("SERVER FILES")
time.sleep(1)
listDirectoryOnRemote('.')
time.sleep(1)

ftp.quit()