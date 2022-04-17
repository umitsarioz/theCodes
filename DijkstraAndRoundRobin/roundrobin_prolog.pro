implement main
    open core

domains
    match = p(integer, integer).
    free_teams = integer*.
    draw = match*.
    free_matches = match*.

clauses
    run() :-
        console::init(),

%       console::write("Enter number of teams : "), console::readint(Num_teams),
        Num_teams = 22,

        console::writef("Generating teams draw for % teams.\n", Num_teams),
        console::write("<[ctrl][break] to stop>\n\n"),

        StartTime = time::new(),
        StartTime:getTimeDetailed(Hr, Min, Sec),

        do_draw(Num_teams, Draw),
        Matches = Num_teams div 2,
        write_draw(Num_teams, Matches, Draw),!,

        EndTime = time::new(),
        EndTime:getTimeDetailed(Hr1, Min1, Sec1),

        DeltaTime = timeInterval::new(StartTime, EndTime),
        DeltaTime:getIntervalDetailed(_, Hr2, Min2, Sec2),

        console::writef("\n\nStart time   : %03u:%02u:%05.2f",     Hr,  Min,  Sec),
        console::writef(  "\nStop  time   : %03u:%02u:%05.2f",     Hr1, Min1, Sec1),
        console::writef(  "\nElapsed time : %03u:%02u:%05.2f\n\n", Hr2, Min2, Sec2).
    run().

% create a competition draw
class predicates
    do_draw : (integer Teams, draw Draw[out]) nondeterm.
clauses
    do_draw(Teams, Draw):-
        Rounds = Teams-1,
        make_match_list(Teams, Rounds, Match_list),
        select_next_match(Teams, Draw, Match_list, []).

% create a list of free matches
class predicates
    make_match_list : (integer Teams, integer Rounds, free_matches Match_list[out]) multi.
clauses
    make_match_list(1, 0, []).
    make_match_list(X, 0, Z):-
        X1 = X-1, Y1 = X1-1,
        make_match_list(X1, Y1, Z).
    make_match_list(X, Y, [p(X, Y) | Z]):-
        Y1 = Y-1,
        make_match_list(X, Y1, Z).

% create a list of free teams
class predicates
    make_team_list : (integer Teams, free_teams Team_list[out]) multi.
clauses
    make_team_list(1, [1]).
    make_team_list(X, [X|Z]):-
        X1 = X-1,
        make_team_list(X1, Z).

% remove a match from the free list
class predicates
    remove_match : (match Match, free_matches Match_list, free_matches New_match_list) nondeterm (p(o,o),i,o).
clauses
    remove_match(X, [X|Z], Z).
    remove_match(X, [W|Z], [W|V]):- remove_match(X, Z, V).

% remove a team from the free list
class predicates
    remove_team : (integer Team, free_teams Team_list, free_teams New_team_list[out]) determ.
clauses
    remove_team(X, [X|Z], Z):-!.
    remove_team(X, [Y|Z], [Y|W]):- remove_team(X, Z, W).

% select the next match
class predicates
    select_next_match : (integer Teams, draw Draw[out], free_matches Match_list, free_teams Team_list) nondeterm.
clauses
    select_next_match(_, [], [],_).
    select_next_match(Teams, Draw, Match_list, []):-
        console::write("."),
        make_team_list(Teams, Team_list),
        select_next_match(Teams, Draw, Match_list, Team_list).
    select_next_match(Teams, [p(Team1, Team2)|Draw], Match_list, Team_list):-
        remove_match(p(Team1, Team2), Match_list, New_match_list),
        member_of_teams(Team1, Team_list),
        member_of_teams(Team2, Team_list),
        remove_team(Team1, Team_list, Temp_team_list),
        remove_team(Team2, Temp_team_list, New_team_list),
        select_next_match(Teams, Draw, New_match_list, New_team_list).

% write out the draw
class predicates
    write_draw : (integer Teams, integer Matches, draw Draw) nondeterm.
clauses
    write_draw(_, _, []):- console::nl.
    write_draw(N, M, [p(X,Y)|D]):-
        N mod M = 0, console::writef("\n%,%",X,Y), N1 = N-1,
        write_draw(N1, M, D).
    write_draw(N, M, [p(X,Y)|D]):-
        N mod M <> 0, console::writef("  %,%",X,Y), N1 = N-1,
        write_draw(N1, M, D).

% test if team is a member of team list
class predicates
    member_of_teams : (integer Team, free_teams Team_list) nondeterm.
clauses
    member_of_teams(X, [X|_]).
    member_of_teams(X, [_|Y]):- member_of_teams(X, Y).

end implement main

goal
    console::runUtf8(main::run).

% Original Turbo Prolog 1.1 code - works very well!!
/*
domains
    match=p(integer,integer)
    free_teams=integer*
    draw=match*
    free_matches=match*

predicates
    do_draw(integer,draw)
    make_match_list(integer,integer,free_matches)
    make_team_list(integer,free_teams)
    remove_match(match,free_matches,free_matches)
    remove_team(integer,free_teams,free_teams)
    select_next_match(integer,draw,free_matches,free_teams)
    writeout(integer,integer,draw,char)
    screenout(integer,integer,draw)
    warn(integer,integer,integer,integer,integer)
    member_of_teams(integer,free_teams)

goal
    clearwindow,
    write("Enter number of teams : "), readint(Num_teams),
    write("Direct output to printer [Y or N] : "),
    readchar(Redirect), write(Redirect), nl,
    writef("Generating draw for % teams.\n",Num_teams),
    write("<[ctrl][break] to stop>"),nl,
    time(H1,M1,S1,F1),
    writef("Start time : %:%:%.%\n",H1,M1,S1,F1),
    do_draw(Num_teams,Draw),
    time(H2,M2,S2,F2),
    writef("End time   : %:%:%.%\n",H2,M2,S2,F2),
    Eltime=(H2-H1)*3600+(M2-M1)*60+(S2-S1)+(F2-F1)/100,
    writef("Elapsed time (seconds) = %-10.2g\n",Eltime),
    warn(10,5,1000,5,500),
    Matches=Num_teams div 2, writeout(Num_teams,Matches,Draw,Redirect).

clauses
%   create a competition draw
    do_draw(Teams,Draw):-
        Rounds=Teams-1,
        make_match_list(Teams,Rounds,Match_list),
        select_next_match(Teams,Draw,Match_list,[]).

%   select the next match
    select_next_match(_,[],[],_).
    select_next_match(Teams,Draw,Match_list,[]):-
        make_team_list(Teams,Team_list),
        select_next_match(Teams,Draw,Match_list,Team_list).
    select_next_match(Teams,[p(Team1,Team2)|Draw],Match_list,Team_list):-
        remove_match(p(Team1,Team2),Match_list,New_match_list),
        member_of_teams(Team1,Team_list),
        member_of_teams(Team2,Team_list),
        remove_team(Team1,Team_list,Temp_team_list),
        remove_team(Team2,Temp_team_list,New_team_list),
        select_next_match(Teams,Draw,New_match_list,New_team_list).

%   create a list of free matches
    make_match_list(1,0,[]).
    make_match_list(X,0,Z):- X1=X-1, Y1=X1-1, make_match_list(X1,Y1,Z).
    make_match_list(X,Y,[p(X,Y)|Z]):- Y1=Y-1, make_match_list(X,Y1,Z).

%   create a list of free teams
    make_team_list(1,[1]).
    make_team_list(X,[X|Z]):- X1=X-1, make_team_list(X1,Z).

%   remove a match from the free list
    remove_match(X,[X|Z],Z).
    remove_match(X,[W|Z],[W|V]):- remove_match(X,Z,V).

%   remove a team from the free list
    remove_team(X,[X|Z],Z):-!.
    remove_team(X,[Y|Z],[Y|W]):- remove_team(X,Z,W).

    member_of_teams(X,[X|_]).
    member_of_teams(X,[_|Y]):- member_of_teams(X,Y).

%   select output device
    writeout(N,M,D,R):-
        R='Y' or R='y', writedevice(printer),
        writef("Draw for % teams"), nl, nl,
        screenout(N,M,D), nl, nl, nl.
    writeout(N,M,D,R):-
        R<>'Y' and R<>'y', screenout(N,M,D).

%   write out the draw
    screenout(_,_,[]):-
        nl, writedevice(screen).
    screenout(N,M,[p(X,Y)|D]):-
        N mod M = 0, writef("\n%,%",X,Y), N1=N-1,
        screenout(N1,M,D).
    screenout(N,M,[p(X,Y)|D]):-
        N mod M <> 0, writef("  %,%",X,Y), N1=N-1,
        screenout(N1,M,D).

%   sound warning tones
    warn(0,_,_,_,_).
    warn(N,D1,F1,D2,F2):-
        sound(D1,F1),sound(D2,F2), N1=N-1, warn(N1,D1,F1,D2,F2).
*/

% Sample outputs from original version
/*
4 Teams

Round 1   4,3     2,1
Round 2   4,2     3,1
Round 3   4,1     3,2

6 Teams

Round 1   6,5     4,3    2,1
Round 2   6,4     5,2    3,1
Round 3   6,3     5,1    4,2
Round 4   6,2     5,3    4,1
Round 5   6,1     5,4    3,2

8 Teams

Round 1   8,7     6,5    4,3    2,1
Round 2   8,6     7,5    4,2    3,1
Round 3   8,5     7,6    4,1    3,2
Round 4   8,4     7,3    6,2    5,1
Round 5   8,3     7,4    6,1    5,2
Round 6   8,2     7,1    6,4    5,3
Round 7   8,1     7,2    6,3    5,4

10 Teams

Round 1   10,9    8,7    6,5    4,3    2,1
Round 2   10,8    9,7    6,4    5,2    3,1
Round 3   10,7    9,8    6,3    5,1    4,2
Round 4   10,6    9,5    8,4    7,1    3,2
Round 5   10,5    9,6    8,3    7,2    4,1
Round 6   10,4    9,3    8,2    7,5    6,1
Round 7   10,3    9,2    8,1    7,6    5,4
Round 8   10,2    9,1    8,6    7,4    5,3
Round 9   10,1    9,4    8,5    7,3    6,2

12 Teams

Round 1   12,11  10,9    8,7    6,5    4,3    2,1
Round 2   12,10  11,9    8,6    7,5    4,2    3,1
Round 3   12,9   11,10   8,5    7,6    4,1    3,2
Round 4   12,8   11,7   10,4    9,3    6,2    5,1
Round 5   12,7   11,8   10,3    9,4    6,1    5,2
Round 6   12,6   11,5   10,2    9,1    8,4    7,3
Round 7   12,5   11,6   10,1    9,2    8,3    7,4
Round 8   12,4   11,3   10,6    9,5    8,2    7,1
Round 9   12,3   11,4   10,5    9,6    8,1    7,2
Round 10  12,2   11,1   10,8    9,7    6,4    5,3
Round 11  12,1   11,2   10,7    9,8    6,3    5,4

14 Teams

Round 1   14,13  12,11  10,9    8,7    6,5    4,3    2,1
Round 2   14,12  13,11  10,8    9,7    6,4    5,2    3,1
Round 3   14,11  13,12  10,7    9,8    6,3    5,1    4,2
Round 4   14,10  13,9   12,8   11,7    6,2    5,3    4,1
Round 5   14,9   13,10  12,7   11,8    6,1    5,4    3,2
Round 6   14,8   13,6   12,5   11,4   10,3    9,2    7,1
Round 7   14,7   13,5   12,6   11,3   10,4    9,1    8,2
Round 8   14,6   13,8   12,4   11,5   10,1    9,3    7,2
Round 9   14,5   13,7   12,3   11,6   10,2    9,4    8,1
Round 10  14,4   13,2   12,10  11,1    9,6    8,5    7,3
Round 11  14,3   13,1   12,9   11,2   10,6    8,4    7,5
Round 12  14,2   13,4   12,1   11,10   9,5    8,3    7,6
Round 13  14,1   13,3   12,2   11,9   10,5    8,6    7,4

16 Teams

Round 1   16,15  14,13  12,11  10,9    8,7    6,5    4,3    2,1
Round 2   16,14  15,13  12,10  11,9    8,6    7,5    4,2    3,1
Round 3   16,13  15,14  12,9   11,10   8,5    7,6    4,1    3,2
Round 4   16,12  15,11  14,10  13,9    8,4    7,3    6,2    5,1
Round 5   16,11  15,12  14,9   13,10   8,3    7,4    6,1    5,2
Round 6   16,10  15,9   14,12  13,11   8,2    7,1    6,4    5,3
Round 7   16,9   15,10  14,11  13,12   8,1    7,2    6,3    5,4
Round 8   16,8   15,7   14,6   13,5   12,4   11,3   10,2    9,1
Round 9   16,7   15,8   14,5   13,6   12,3   11,4   10,1    9,2
Round 10  16,6   15,5   14,8   13,7   12,2   11,1   10,4    9,3
Round 11  16,5   15,6   14,7   13,8   12,1   11,2   10,3    9,4
Round 12  16,4   15,3   14,2   13,1   12,8   11,7   10,6    9,5
Round 13  16,3   15,4   14,1   13,2   12,7   11,8   10,5    9,6
Round 14  16,2   15,1   14,4   13,3   12,6   11,5   10,8    9,7
Round 15  16,1   15,2   14,3   13,4   12,5   11,6   10,7    9,8

18 Teams

Round 1   18,17  16,15  14,13  12,11  10,9    8,7    6,5    4,3    2,1
Round 2   18,16  17,15  14,12  13,11  10,8    9,7    6,4    5,2    3,1
Round 3   18,15  17,16  14,11  13,12  10,7    9,8    6,3    5,1    4,2
Round 4   18,14  17,13  16,12  15,11  10,6    9,5    8,4    7,1    3,2
Round 5   18,13  17,14  16,11  15,12  10,5    9,6    8,3    7,2    4,1
Round 6   18,12  17,11  16,14  15,13  10,4    9,3    8,2    7,5    6,1
Round 7   18,11  17,12  16,13  15,14  10,3    9,2    8,1    7,6    5,4
Round 8   18,10  17,9   16,8   15,7   14,6   13,4   12,2   11,1    5,3
Round 9   18,9   17,10  16,7   15,8   14,5   13,3   12,1   11,4    6,2
Round 10  18,8   17,7   16,10  15,6   14,4   13,5   12,3   11,2    9,1
Round 11  18,7   17,8   16,9   15,5   14,3   13,2   12,4   11,6   10,1
Round 12  18,6   17,5   16,4   15,10  14,2   13,1   12,9   11,8    7,3
Round 13  18,5   17,6   16,3   15,4   14,1   13,9   12,8   11,7   10,2
Round 14  18,4   17,3   16,2   15,1   14,10  13,7   12,6   11,9    8,5
Round 15  18,3   17,4   16,1   15,2   14,9   13,10  12,7   11,5    8,6
Round 16  18,2   17,1   16,6   15,3   14,7   13,8   12,5   11,10   9,4
Round 17  18,1   17,2   16,5   15,9   14,8   13,6   12,10  11,3    7,4

20 Teams

Round 1   20,19  18,17  16,15  14,13  12,11  10,9    8,7   6,5     4,3    2,1
Round 2   20,18  19,17  16,14  15,13  12,10  11,9    8,6   7,5     4,2    3,1
Round 3   20,17  19,18  16,13  15,14  12,9   11,10   8,5   7,6     4,1    3,2
Round 4   20,16  19,15  18,14  17,13  12,8   11,7   10,4   9,3     6,2    5,1
Round 5   20,15  19,16  18,13  17,14  12,7   11,8   10,3   9,4     6,1    5,2
Round 6   20,14  19,13  18,16  17,15  12,6   11,5   10,2   9,1     8,4    7,3
Round 7   20,13  19,14  18,15  17,16  12,5   11,6   10,1   9,2     8,3    7,4
Round 8   20,12  19,11  18,10  17,9   16,8   15,7   14,2   13,1    6,4    5,3
Round 9   20,11  19,12  18,9   17,10  16,7   15,8   14,1   13,2    6,3    5,4
Round 10  20,10  19,9   18,12  17,11  16,6   15,5   14,4   13,3    8,2    7,1
Round 11  20,9   19,10  18,11  17,12  16,5   15,6   14,3   13,4    8,1    7,2
Round 12  20,8   19,7   18,6   17,5   16,4   15,3   14,10  13,9   12,2   11,1
Round 13  20,7   19,8   18,5   17,6   16,3   15,4   14,9   13,10  12,1   11,2
Round 14  20,6   19,5   18,4   17,3   16,2   15,1   14,12  13,11  10,8    9,7
Round 15  20,5   19,6   18,3   17,4   16,1   15,2   14,11  13,12  10,7    9,8
Round 16  20,4   19,3   18,2   17,1   16,12  15,11  14,8   13,7   10,6    9,5
Round 17  20,3   19,4   18,1   17,2   16,11  15,12  14,7   13,8   10,5    9,6
Round 18  20,2   19,1   18,8   17,7   16,10  15,9   14,6   13,5   12,4   11,3
Round 19  20,1   19,2   18,7   17,8   16,9   15,10  14,5   13,6   12,3   11,4

22 Teams                                            

Round 1   22,21  20,19  18,17  16,15  14,13  12,11  10,9    8,7    6,5    4,3    2,1
Round 2   22,20  21,19  18,16  17,15  14,12  13,11  10,8    9,7    6,4    5,2    3,1
Round 3   22,19  21,20  18,15  17,16  14,11  13,12  10,7    9,8    6,3    5,1    4,2
Round 4   22,18  21,17  20,16  19,15  14,10  13,9   12,8   11,7    6,2    5,3    4,1
Round 5   22,17  21,18  20,15  19,16  14,9   13,10  12,7   11,8    6,1    5,4    3,2
Round 6   22,16  21,15  20,18  19,17  14,8   13,6   12,5   11,4   10,3    9,2    7,1
Round 7   22,15  21,16  20,17  19,18  14,7   13,5   12,6   11,3   10,4    9,1    8,2
Round 8   22,14  21,13  20,12  19,11  18,10  17,6   16,5   15,4    9,3    8,1    7,2
Round 9   22,13  21,14  20,11  19,12  18,9   17,5   16,6   15,2   10,1    8,4    7,3
Round 10  22,12  21,11  20,14  19,13  18,8   17,4   16,3   15,1   10,2    9,6    7,5
Round 11  22,11  21,12  20,13  19,14  18,7   17,2   16,1   15,6   10,5    9,4    8,3
Round 12  22,10  21,9   20,8   19,7   18,14  17,3   16,4   15,5   13,2   12,1   11,6
Round 13  22,9   21,10  20,7   19,8   18,13  17,1   16,2   15,3   14,6   12,4   11,5
Round 14  22,8   21,7   20,6   19,5   18,4   17,14  16,10  15,9   13,3   12,2   11,1
Round 15  22,7   21,8   20,5   19,6   18,3   17,12  16,9   15,10  14,4   13,1   11,2
Round 16  22,6   21,5   20,10  19,9   18,2   17,13  16,11  15,8   14,1   12,3    7,4
Round 17  22,5   21,6   20,9   19,3   18,1   17,11  16,8   15,7   14,2   13,4   12,10
Round 18  22,4   21,3   20,2   19,1   18,12  17,10  16,14  15,13  11,9    8,5    7,6
Round 19  22,3   21,4   20,1   19,2   18,11  17,9   16,7   15,12  14,5   13,8   10,6
Round 20  22,2   21,1   20,4   19,10  18,6   17,8   16,12  15,11  14,3   13,7    9,5
Round 21  22,1   21,2   20,3   19,4   18,5   17,7   16,13  15,14  12,9   11,10   8,6

*/                                           




