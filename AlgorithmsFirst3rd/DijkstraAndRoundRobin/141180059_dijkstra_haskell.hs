--141180059, Ümit SARIÖZ :: Programlama Dilleri Ödev 1 :: Haskell ile Dijkstra Algoritması


-- Grafı çalıştırmak için : 
-- bu dijkstra.hs dosyasını load edilmeli.
-- grafYukle ile txt halindeki graf yuklenmeli bir fonksiyonla dijkstra algo. çalıştırılabilir. 
-- örnek kullanım : 
--ghci
--Prelude>:load djikstra.hs
--Djikstra> :browse DijkstraAlgoritmasi
--Dijkstra> txt <- readFile "graph.txt"
--Dijkstra > let graf = grafYukle txt False
--İstenilen node'un diger komsularına olan uzaklıklarını görmek için:
--Dijkstra > kenarIslemleri graf "istenilen_node"
--Başlangıç noktasından diğer node'lara en kısa yolu görmek için : 
--Dijkstra > let calistir =dijkstra graf "baslangic_node'u"
--Dijkstra > calistir
--İstenilen bir node'a ulaşmak için hangi yolu kullanmamız gerektiğini görmek için:
--Dijkstra > guzergah calistir "istenen node" 

module DijkstraAlgoritmasi 
(
  grafYukle,
  dijkstra,
  guzergah,
  kenarIslemleri,
  Kenar(..),
  Dugum,
  Graf,
  Maliyet
) where

import Data.List
import System.IO

data Kenar = Kenar { dugum::Dugum, maliyet::Float } deriving (Show) -- mesafeleri tut.
type Dugum = String -- Dugum 
type Graf = [(Dugum, [Kenar])] -- graf yapısı 
type Maliyet = (Dugum, (Float, Dugum)) -- Dugum 1 , ağılık, Dugum2 
-- Bir text dosyasından satırları okuyarak Grafı al.
-- Eğer Graf yönsüz verilmişse bunu kontrol et ve yönlü hale getir.Böylece negatif deger hatalarından kurtuluyor.

grafYukle :: String -> Bool -> Graf
grafYukle strLines isDigraph = 
  let oku [n1, n2, w] = ((n1, n2), read w :: Float)
      es = map (oku . words) $ lines strLines
      allEs = if isDigraph then es 
              else tersCevir es
  in listeyeYukle allEs
-- ters çevirme işlemi 
tersCevir :: [((String, String), Float)] -> [((String, String), Float)]
tersCevir es = es ++ map (\((n1,n2),w) -> ((n2,n1),w)) es

-- Listeden eleman al . 
listeyeYukle :: [((String, String), Float)] -> Graf
listeyeYukle es =
  let nodes = nub . map (fst . fst) $ es
      kenarIslemleri es dugum = 
        let connected = filter (\((n,_),_) -> dugum == n) $ es
        in map (\((_,n),wt) -> Kenar n wt) connected 
  in map (\n -> (n, kenarIslemleri es n)) nodes

-- bir graf ve düğüm için, Dugum'un maliyetini geri döndürür.
kenarIslemleri :: Graf -> Dugum -> [Kenar]
kenarIslemleri g n = snd . head . filter (\(nd, _) -> nd == n) $ g


-- bir düğümle kenarları verildiğinde tüm kenarların maliyetlerini dönürür.
maliyetIslemleri :: Dugum -> [Kenar] -> Float
maliyetIslemleri n = maliyet . head . filter (\e -> n == dugum e)

-- bir kenarın baglı oldugu Dugumları döndürür.
bagliNodelar :: [Kenar] -> [Dugum]
bagliNodelar = map dugum

birDugumunMaliyeti :: [Maliyet] -> Dugum -> Maliyet
birDugumunMaliyeti dugumlerinMaliyeti n = head . filter (\(x, _) -> x == n) $ dugumlerinMaliyeti


-- graf ve başlangıc Dugum'u verilir.
dijkstra :: Graf -> Dugum -> [Maliyet]
dijkstra g baslangic = 
  let dugumlerinMaliyeti = initM g baslangic
      zedilmemis = map fst dugumlerinMaliyeti
  in  dijkstra' g dugumlerinMaliyeti zedilmemis

-- Grafı ve başlangıc noduyla graf olusturulur.
initM :: Graf -> Dugum -> [Maliyet]
initM g baslangic =
  let initMaliyet (n, es) = 
        if n == baslangic 
        then 0 
        else if baslangic `elem` bagliNodelar es
             then maliyetIslemleri baslangic es
             else 1.0/0.0
  in map (\pr@(n, _) -> (n, ((initMaliyet pr), baslangic))) g

--Recursive olarak dijkstra algoritması gerçekleştirimi -----
--Ziyaret edilmemiş ziyaretEdilenDugum'lar alınır. ( DugumMaliyeti: Ziyaret edilecek Dugumların graf gösterimiyle maliyeti)
--Diğer dillerden Örnek: (0,1) =5 gibi 
--En az maliyeti olanı alıp ziyaret edilmişler listesine eklenir.Sonra mevcut deger cagırır.
--Mevcut Dugum'a baglı her DugumMaliyeti karsılastırılarak güncelleme yapılır
--DugumMaliyeti'un toplam mesafesi = bağlantılı kenarın maliyeti + mevcut olanın maliyeti olur .
--algoritma tüm düğümler kontrol edilince biter.

dijkstra' :: Graf -> [Maliyet] -> [Dugum] -> [Maliyet]
dijkstra' g dugumlerinMaliyeti [] = dugumlerinMaliyeti
dijkstra' g dugumlerinMaliyeti zedilmemis = 
  let zedilmemisMaliyet = filter (\dn -> (fst dn) `elem` zedilmemis) dugumlerinMaliyeti
      current = head . sortBy (\(_,(d1,_)) (_,(d2,_)) -> compare d1 d2) $ zedilmemisMaliyet
      c = fst current
      zedilmemis' = delete c zedilmemis
      kenarlar = kenarIslemleri g c
      cnodes = intersect (bagliNodelar kenarlar) zedilmemis'
      dugumlerinMaliyeti' = map (\dn -> guncelle dn current cnodes kenarlar) dugumlerinMaliyeti
  in dijkstra' g dugumlerinMaliyeti' zedilmemis' 

-- Mümkün olan en iyi DugumMaliyeti : mevcut dügüm, baglı oldugu dügümler ve maliyetleri eklenerek güncelleme yapılır.

guncelle :: Maliyet -> Maliyet -> [Dugum] -> [Kenar] -> Maliyet
guncelle dn@(n, (nd, p)) (c, (cd, _)) cnodes kenarlar =
  let wt = maliyetIslemleri n kenarlar
  in  if n `notElem` cnodes then dn
      else if cd+wt < nd then (n, (cd+wt, c)) else dn

-- Dijkstra çözümü ve hedef Dugum verilir ve hedef Dugum'un minimum maliyetli yolunu döndürü.
guzergah :: [Maliyet] -> Dugum -> [Dugum]
guzergah dugumlerinMaliyeti hedef = 
  let dn@(n, (d, p)) = birDugumunMaliyeti dugumlerinMaliyeti hedef
  in if n == p then [n] else guzergah dugumlerinMaliyeti p ++ [n]
