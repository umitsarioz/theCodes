import java.util.ArrayList;
import java.util.Scanner;

class BST {
  class Node {
    int key;
    Node left, right;

    public Node(int key) {
      this.key = key;
      left = right = null;
    }
  }  // belirli bir indeksteki node için sol ve sag cocugu tutacak sınıf .

  Node root; // kök .

  BST() {
    root = null;
  }// yapıcı metod

  void initializeBST(int key) {
    root = ekleRec(root, key);
  }

  // 1.soru
  void ekle(int key) {
    root = ekleRec(root, key);
  }

  Node ekleRec(Node root, int key) {
    if (root == null) {  // Ağaç boşsa yeni bir node oluşturup ekle .
      root = new Node(key);
      return root; // kökü return et.
    }
    if (key < root.key) // eklenen deger köktekinden kücükse sola ekleme yap.
      root.left = ekleRec(root.left, key);
    else if (key > root.key) // eklenen deger kökten büyükse saga ekleme yap.
      root.right = ekleRec(root.right, key);
    return root; // kökü return et .
  } // ekleme yapan fonksiyon.

  // 2.soru
  void sil(int eleman) {
    root = silRec(root, eleman);
  }

  Node silRec(Node root, int silinecekEleman) {
    if (root == null) return root; // Ağaç boşsa
    if (silinecekEleman < root.key) // Ağacın kökü girdigimiz degerden büyükse
      root.left = silRec(root.left, silinecekEleman);
    else if (silinecekEleman > root.key) // Girdigiğimiz değer ağacın kökünden büyükse
      root.right = silRec(root.right, silinecekEleman);
    else // Girdiğimiz değer kökle aynıysa
    {
      // eğer tek cocugu varsa
      if (root.left == null) // kök null sa
        return root.right; // sag cocugu döndür.
      else if (root.right == null) // kökün sag cocugu da yoksa
        return root.left; // sol cocugu döndür.
      root.key = kücükBul(root.right); // iki cocugu varsa sag minimuma al.
      root.right = silRec(root.right, root.key); // ve sil .
    }

    return root;
  }

  int kücükBul(Node root) {
    int enk = root.key; // en kücük kök
    while (root.left != null) // kök null degilse
    {
      enk = root.left.key; // en kucugu kökün sol elemanı yap
      root = root.left; // kökü de kökün sol elemnı yap .
    }
    return enk; // return enkücük
  }

  // 3.soru
  // Array List'leri inorder,preorder ve postorder şeklinde yazdırmak için kullandım. İçerideki işlemler dolaşmalarla aynı mantıkda oldugundan acıklamadım dolaşma fonksiyonlarında açıklamaları mevcut.
  public ArrayList<Integer> preOrderBSTtoArr(Node node, ArrayList<Integer> preOrderArray)
  {
    if(node == null)
      return preOrderArray;
    preOrderArray.add(node.key);
    preOrderBSTtoArr(node.left, preOrderArray);
    preOrderBSTtoArr(node.right, preOrderArray);

    return preOrderArray;
  }

  public ArrayList<Integer> inOrderBSTtoArr(Node node, ArrayList<Integer> inOrderArray)
  {
    if(node == null)
      return inOrderArray;

    inOrderBSTtoArr(node.left, inOrderArray);
    inOrderArray.add(node.key);
    inOrderBSTtoArr(node.right, inOrderArray);

    return inOrderArray;
  }
  public ArrayList<Integer> postOrderBSTtoArr(Node node, ArrayList<Integer> postOrderArray)
  {
    if(node == null)
      return postOrderArray;

    postOrderBSTtoArr(node.left, postOrderArray);
    postOrderBSTtoArr(node.right, postOrderArray);
    postOrderArray.add(node.key);


    return postOrderArray;
  }
  // indexBul fonksiyonu aradığımız değerin dolaşma türüne göre indeks degerini bulup bize yerini yazdırıyor.
  void indexBul(ArrayList<Integer> arrList,int aranan){
    for(int i=0;i<arrList.size();i++)
    {
      if(arrList.get(i)==aranan)
      {
        System.out.print("Aranan sayı "+i+".indekste mevcut.");
      }
    }
  }
  boolean find(int aranan) {
    Node current = root;
    while (current != null) { // kök boş degilse
      if (current.key == aranan) { // aranan deger bulunduysa
        return true;
      }
      else if (current.key > aranan) { // aranan deger mevccut degerden kücükse solda kalıyor demektir. Mevcutu sol cocuk yap.
        current = current.left;
      }
      else {
        current = current.right; // Aranan değer mevcut değerden büyükse sağda kalıyordur.Mevcutu sağ çocuk yap.
      }
    }
    return false;
  } // Aranan değer dizide var mı yok mu  ?
  // derinligi buluyorum.Bunun için ilk baştaki BST şeklinde verdiğim array'i kullanıyorum.
  int derinlikBul(int depth) {
    depth =(int)(Math.log(depth) / Math.log(2));
    return depth;
  }
  // İndeksi parent ve çocuklrı bulurken kullanacağımdan linear search algoritmasıyla buluyorum.
  int IndeksiBul(int[]dizi,int aranan){
    for(int i=0;i<dizi.length;i++)
      if(dizi[i]==aranan)
        return i;
      return -1;
  }
  int parent(int i){
    if(i==0)
      return -1;
    else if(i%2==0)
      return (i/2)-1;
    else
      return i/2;
  }
  int solcocuk(int i){
      return 2*(i+1)-1;
  }
  int sagcocuk(int i){
      return 2*(i+1);
  }

  // Dolaşma fonksiyonları
  void inOrder() {
    System.out.print("\nInorder: ");
    if (root != null) {
      inOrderRec(root);
    } else
      System.out.print("Dizi Boştur.");
  }
  void inOrderRec(Node root) {
    // Sol alt ağacı inorder dolaş
    // Köke uğra
    // Sağ alt ağacı inorder dolaş
    if (root != null) {
      inOrderRec(root.left);
      System.out.print(root.key + " ");
      inOrderRec(root.right);
    }
  }
  void preOrder() {
    System.out.print("\nPreorder: ");
    if(root!=null) {
      preOrderRec(root);
    }
    else
      System.out.print("Dizi Boştur.");
  }
  void preOrderRec(Node root) {
    // Köke uğra
    // Sol alt ağacı preOrder dolaş
    // Sağ alt ağacı preOrder dolaş
    if (root != null) {
      System.out.print(root.key + " ");
      preOrderRec(root.left);
      preOrderRec(root.right);
    }
  }
  void postOrder() {
    System.out.print("\nPostorder: ");
    if(root!=null)
      postOrderRec(root);
    else
      System.out.print("Dizi Boştur.");
  }
  void postOrderRec(Node root) {
    // Sol alt ağacı postOrder dolaş
    // Sağ alt ağacı postOrder dolaş
    // köke uğra
    if (root != null) {
      postOrderRec(root.left);
      postOrderRec(root.right);
      System.out.print(root.key + " ");
    }
  }

}
  public  class Main {

  /*  BST kodunu yaz :
    a)	Yeni eleman ekleme: Console’dan veya görsel arayüzden girilebilen yeni eleman eklenebilmeli ve ekleme sonrası sıralı ağaç; preorder, inorder, postorder şeklinde ekrana yazdırılmalıdır.
    b)	Eleman silme: girilen değer ağaçtan silinmeli ve silme sonrası sıralı ağaç; preorder, inorder, postorder şeklinde ekrana yazdırılmalıdır. (Ağaçta olmayan eleman silinemez )
    c)	Arama yapma: girilen değerin preorder, inorder ve postorder daki sıra sayısı, hangi derinlikte olduğu parent(sadece bir tane) ve child’ları yazılmalıdır.
*/
    // Takıldığım yerde kaynak olarak Suat hocanın Algoritmalar ders slaytlarını ve Akcayol hocamızın veriyapıları slaytlarını kullandım.

    public static void main(String[] args) {

      int[] agac = {56, 26, 200, 18, 28,190,213,12,24,27};
      // Sıralama :
      // Level order:56,26,200,18,28,190,213,12,24,27
      // Pre order: 56,26,18,12,24,28,27,200,190,213
      // Inorder:12,18,24,26,27,28,56,190,200,213
      // Postorder: 12,24,18,27,28,26,190,213,200,56
      BST yeniAgac = new BST();
      for (int i = 0; i < agac.length; i++) // BST ' yi arrayden ekledim .
        yeniAgac.initializeBST(agac[i]);
      // SIRALAMA İŞLEMİ
      System.out.print("İkili Ağaç:");
      for(int o:agac)
        System.out.print(o+" ");
      yeniAgac.preOrder();
      yeniAgac.inOrder();
      yeniAgac.postOrder();

      // Ağac elemanlarını istenilen(pre,in,post---order) sırada listeye al .
      ArrayList<Integer> preOrderAL= new ArrayList<Integer>();
      ArrayList<Integer> inOrderAL= new ArrayList<Integer>();
      ArrayList<Integer> postOrderAL= new ArrayList<Integer>();
      yeniAgac.inOrderBSTtoArr(yeniAgac.root,inOrderAL);
      yeniAgac.preOrderBSTtoArr(yeniAgac.root,preOrderAL);
      yeniAgac.postOrderBSTtoArr(yeniAgac.root,postOrderAL);

      // Kullanıcıdan işlem için girdi al.
      Scanner scan = new Scanner(System.in);
      byte secenek = 0;
      System.out.print("\nİŞLEMLER\n---------\n1-)Ekleme" + "\n2-)Silme" + "\n3-)Arama" +
              "\nYapmak istediginiz işlemi seçiniz(1,2,3):");
      secenek = scan.nextByte();
      switch (secenek) {
        case 1: {
          boolean eklemeVar = true;
          while (eklemeVar) {
            if (yeniAgac.root != null) {
              System.out.print("\nEklemek istediginiz degeri giriniz(Çıkış için -1):");
              int eklenecekDeger = scan.nextInt();
              if (eklenecekDeger == -1)
                break;
              yeniAgac.ekle(eklenecekDeger); // Ekleme Yap
              // SIRALA
              yeniAgac.preOrder();
              yeniAgac.inOrder();
              yeniAgac.postOrder();
            }
          }
        }
        case 2: {
          boolean silmeVar = true;
          while (silmeVar) {
            System.out.print("\nSilmek istediginiz degeri giriniz(Çıkış için -1):");
            int silinecekDeger = scan.nextInt();
            if (silinecekDeger == -1)
              silmeVar = false;
            yeniAgac.sil(silinecekDeger); // Silme yap
            // SIRALA
            yeniAgac.preOrder();
            yeniAgac.inOrder();
            yeniAgac.postOrder();
          }

        }
        case 3: {

          boolean aramaVar = true;
          while (aramaVar) {
            System.out.print("\nAramak istediğiniz değeri giriniz(Çıkış için -1):");
            int aranacakDeger = scan.nextInt();
            if (aranacakDeger == -1)
              aramaVar = false;
            if(yeniAgac.find(aranacakDeger))
            {
              // DOLAŞMA TÜRÜNE GÖRE KONUMLARINI YAZ.
              System.out.print("Indeks değerleri 0 dan başlamaktadır.");
              System.out.print("\nPreorder Konumu:");
              yeniAgac.indexBul(preOrderAL,aranacakDeger);
              System.out.print("\nInorder Konumu:");
              yeniAgac.indexBul(inOrderAL,aranacakDeger);
              System.out.print("\nPostorder Konumu:");
              yeniAgac.indexBul(postOrderAL,aranacakDeger);
              // PARENT VE COCUKLARI BULMAK ICIN INDEKSI HESAPLA VE GEREKLİ FONKSİYONLARI CALISTIRDIM.
              int indeks = yeniAgac.IndeksiBul(agac,aranacakDeger); // Sayının bst 'deki mevcut indeksini bul.
              int parent = yeniAgac.parent(indeks);
              int solCocuk = yeniAgac.solcocuk(indeks);
              int sagCocuk = yeniAgac.sagcocuk(indeks);
              System.out.print("\n"+aranacakDeger+" elemanının"+" derinliği: "+yeniAgac.derinlikBul(indeks+1)); // Derinliğini hesapla ve yazdır.
              if(parent!=-1)
                System.out.print("\nParent:"+agac[parent]);
              else
                System.out.print("\nParent: Kök node->Parenti YOK.");
              try {
                System.out.print("\nSol Çocuk:" + agac[solCocuk]);
              }catch(IndexOutOfBoundsException e) { // EĞER INDEKS YOKSA EXCEPTION ALIYORSAK O DUGUM NULL DIR Dolayısıyla boştur.
                System.out.print("\nSol Çocuk: YOK");
              }
              try {
                System.out.print("\nSag Çocuk:" + agac[sagCocuk]);
              }catch(IndexOutOfBoundsException e)
              {
                System.out.print("\nSag Çocuk: YOK");
              }
            }
            else
              System.out.print("Sayı ağaçta mevcut degil.");// Find fonksiyonu fasle degeri verdiyse yoktur.

          }

        }
        default: System.out.print("Mevcut bir seçenek seçiniz :)");
      }

    }
  }
