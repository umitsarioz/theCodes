# 141180059 - Ümit SARIÖZ :: Programlama  Dilleri Ödev 1 :: Ruby Round Robin 
class RRSAlgorithm
  processes = %w[p1 p2 p3 p4 p5 ]

  def toSchedule(processes, time_slice:)
    processes = processes.shuffle
    running_times = processes.each_slice(time_slice).to_a
    processes.push(nil) if processes.size.odd?
    puts "Adımlar"
    running_times.size.times do |index|
      run_time = running_times[index]
      matches = []
      steps = run_time.size - 1
      steps.times do |step_index|
        matches[step_index] = []
        matches_per_step = run_time.size / 2
        matches_per_step.times do |match_index|
          matches[step_index] << [run_time[match_index], run_time.reverse[match_index]]
        end
        puts matches.inspect 
        run_time = [run_time[0]] + run_time[1..-1].rotate(-1)
      end
        puts "Çalışma Anı:"
       puts run_time.inspect
    end
  end
