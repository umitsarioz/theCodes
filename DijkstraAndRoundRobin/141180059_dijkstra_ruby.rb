# 141180059 - Ümit SARIÖZ :: Programlama Dilleri Ödev 1 :: Ruby ile Dijkstra Algoritması .
class Graph
  # Constructor
  def initialize
    @g = {}	 # graf // {düğüm => { kenar1 => mesafe, kenar2 => mesafe}, düğüm2 => ...
    @dugumler = Array.new
    @INFINITY = 1 << 64
  end
  def dugumEkle(baslangic,hedef,mesafe)
    if (not @g.has_key?(baslangic))
      @g[baslangic] = {hedef=>mesafe}
    else
      @g[baslangic][hedef] = mesafe
    end
    # Begin code for non directed graph (inserts the other edge too)
    if (not @g.has_key?(hedef))
      @g[hedef] = {baslangic=>mesafe}
    else
      @g[hedef][baslangic] = mesafe
    end
    # End code for non directed graph (ie. deleteme if you want it directed)
    if (not @dugumler.include?(baslangic))
      @dugumler << baslangic
    end
    if (not @dugumler.include?(hedef))
      @dugumler << hedef
    end
  end
  # pseudo-kod: wiki
  def dijkstra(baslangic)
    @d = {} # mesafeler anlamında distances , d
    @prev = {}
    @dugumler.each do |i|
      @d[i] = @INFINITY #Tüm mesafeleri sonsuz yap.
      @prev[i] = -1
    end
    @d[baslangic] = 0
    q = @dugumler.compact
    while (q.size > 0)
      u = nil;
      q.each do |min|
        if (not u) or (@d[min] and @d[min] < @d[u])
          u = min
        end
      end
      if (@d[u] == @INFINITY)
        break
      end
      q = q - [u]
      @g[u].keys.each do |v|
        alt = @d[u] + @g[u][v]
        if (alt < @d[v])
          @d[v] = alt
          @prev[v]  = u
        end
      end
    end
  end
  #En kısa yolun rotasını yazdır.
  def enKisaYoluYazdir(hedef)
    if @prev[hedef] != -1
      enKisaYoluYazdir @prev[hedef]
    end
    print "->#{hedef} "
  end
  # En kısa yolu ve rotayı göster.
  def baslangicNoktasiSec(baslangic)
    @source = baslangic
    dijkstra baslangic
    puts "Başlangıç: #{@source}"
    @dugumler.each do |hedef|
      puts "\nVarış Noktası:#{hedef}"
      print"Takip edilen Yol:"
      enKisaYoluYazdir hedef
      if @d[hedef] != @INFINITY # Eğer sonsuz degilse yol var ve hesaplama gerçekleşiyor demektir.
        puts "\nEn Kısa Mesafe: #{@d[hedef]}"
      else
        puts "\nYol yok."
      end
    end
  end
end

## elle graph ekledim.
gr = Graph.new
gr.dugumEkle("a","b",5)
gr.dugumEkle("b","c",3)
gr.dugumEkle("c","d",1)
gr.dugumEkle("a","d",10)
gr.dugumEkle("b","d",2)
gr.dugumEkle("f","g",1)
gr.baslangicNoktasiSec("a")