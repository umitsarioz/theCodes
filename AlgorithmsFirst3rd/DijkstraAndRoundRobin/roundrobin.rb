 def findWaitingTime(processes,n,arrBt,arrWt,quantum)
    arrRembt = Array.new(n)
    $i =0
    while $i < n do
      arrRembt[$i] = arrBt[$i] # Kalan burst timedaki elemanların yerine asıl burst timeları koy.
      #puts "process#{$i+1} burst time :#{arrRembt[$i]}" # Elemanları yazdır. 
      $i+=1
    end

    time = 0

    while true
      done = true
      $i=0
      while $i<n do
       # puts "i degeri: #{$i}"
       if arrRembt[$i] >0 then
        done = false
        if arrRembt[$i] > quantum 
          time = time + quantum 
          arrRembt[$i] = arrRembt[$i] - quantum
          #puts "#{$i}. sefer dönüyor time : #{time}"
        else 
          time = time + arrRembt[$i]
          arrWt[$i] = time - arrBt[$i] 
          arrRembt[$i]=0
         # puts "process#{$i} -> Hesaplanan Waiting Time: #{time}"
        end
        end
         $i+=1
      end
      if done == true
        break
    end
  end
end

 
 
 def findTurnAroundTime(processes,n,arrBt,arrWt,arrTat)
	$i=0
  while $i<n 
	arrTat[$i]=arrBt[$i].to_i + arrWt[$i].to_i
	$i+=1
	end
 end
 def findAvgTime (processes,n,arrBt,quantum)
	arrWt = Array.new(n)
	arrTat = Array.new(n)
	$total_wt=0
  $total_tat=0

  #puts "Find Waiting Time Fonksiyonu çalışıyor..."
  findWaitingTime(processes,n,arrBt,arrWt,quantum)
  #puts "Find Turn around Time Fonksiyonu çalışıyor..."
  findTurnAroundTime(processes,n,arrBt,arrWt,arrTat)
	puts "Processes" ++ " | Burst Time" ++ " | Waiting Time" ++ " | Turn around Time"
	#puts "Toplam süreler hesaplanıyor..."
  $i=0

	while $i <n do
  puts " " + "p#{$i+1}" + " \t\t" "#{arrBt[$i]}" + "\t\t" + "#{arrWt[$i]}"+ "\t\t" + "#{arrTat[$i]}"
  $total_wt += arrWt[$i]
  $total_tat += arrTat[$i]
  $i+=1
  end
  puts ("Total Waiting Time: #{$total_wt}")
  puts ("Total Turn Around Time: #{$total_tat}")

  puts("Average Waiting Time: #{($total_wt/n).to_f}")
   puts("Average Turnaround Time: #{($total_tat/n).to_f}")
  
  

end
puts "Kod çalışmaya başlıyor..."
processes = Array[1,2,3]
n = 3
burst_time = Array[10,5,8]
quantum =2
findAvgTime(processes,n,burst_time,quantum)
