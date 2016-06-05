# MacroHard ©


	• Šeila Bećirović

	• Edin Cerić

	• Muhamed Delalić

Naziv teme: ShEM

Da li ste ikada željeli da imate aplikaciju pomoću koje ćete voditi računa o svim stvarima koje volite? Aplikaciju koja omogućava da saznate koliko epizoda neke serije Vam je ostalo, da pronađete Vaše omiljene knjige i citate, te da pročitate recenzije najnovijih filmova i mišljenja drugih ljudi o istim? Sistem „ShEM“  Vam omogućava ovo. On predstavlja sistem razmjene mišljenja i podataka o omiljenim filmovima, serijama, knjigama s drugim korisnicima. Pored toga sistem omogućava da Vi imate vlastitu listu favorita, da ostavljate Vaše vlastite utiske, te da pratite najnovije vijesti i informacije o Vašim interesima.

Procesi 

	• Korisnik kreira vlastiti račun. U procesu kreiranja vlastitog računa, on mora unijeti sljedeće podatke: ime, prezime, username, e-mail adresa, šifra, sigurnosna provjera šifre (case sensitive) i caption check. Pored ovoga korisnik može, ali ne mora upload-ovati profilnu fotografiju. Korisnik će dobiti mail za verifikaciju računa.

	• Korisniku je omogućena pretraga muzike, filmova i knjiga. Korisnik može pretraživati multimediju i bazu preko search textbox-a i raznim mogućnostima filtriranja podataka.

	• Korisniku je omogućena pretraga drugih korisnika, preko search textbox-a, te dodavanja korisnika u following.

	• Omogućeno je da pravi razne liste, privatne i javne. Prilikom search-a i pregleda raznih objekata omogućena su dugmad ADD to specifičnoj kolekciji. 

Funkcionalnosti:

	• Mogućnost kreiranja i editovanja vlastitog računa

	• Mogućnost pretrage baze podataka

	• Mogućnost kreiranja listi

	• Mogućnost praćenja drugih ljudi (followers i following)

	• Mogućnost share-ovanja via bluetooth

	• Mogućnost upload-ovanja slika, i korištenja kamere za instant upload (za profile picture)

	• Mogućnost pristupa svim ShEMWebAPI-ju, gdje se nalazi lista korisnika i mogućnost pretrage istih.

Akteri:

Korisnik usluga: Osoba koja kreira vlastiti account i ima mogućnost pretrage podataka, kreiranja listi, uređivanje listi.

Admin: Osoba koja ažurira podatke, održava bazu podataka kao i reguliše sadržaj korisnika. 

# ShEM HELP 

Sistem ShEM predstavlja sistem interaktivnog kreiranja listi omiljenih filmova, knjiga i muzike. Prilikom pokretanja aplikacije korisnik se može prijaviti, te na taj način pristupiti svom NewsFeed-u. U slučaju da korisnik nema korisnički račun, pritiskom na dugme Register omogućeno mu je kreiranje vlastitog računa. Ako je korisnik zaboravio svoje korisničke podatke omogućeno mu je da povrati iste. Unutar vlastitog NewsFeed-a korisnik može pregledavati liste prijatelja. Klikom na MyCollections korisniku je omogućeno da vidi vlastitu kolekciju. Klikom na dugme Settings omogućeno je da edit-uje vlastite korisničke podatke. Preko SearchBar-a korisniku je omogućena pretraga filmova, muzike, korisnika i knjiga. Unutar View-a za artikle korisnik može dodavati artikle u svoju kolekciju. Korisniku je omogućeno dodavanje drugih korisnika u prijatelje. Svim korisnicima je omogućen pristup ShEMWebAPI klikom na dugme. Sistem je prilagođen radu na svim Windows platformama. Hvala Vam na korištenju našeg sistema.
ShEM sistem su razvili članovi tima MacroHard:

	• Šeila Bećirović

	• Edin Cerić

	• Muhamed Delalić
	

# ShEM-Final info
Baza koja se koristi je remote i implementirana je na eksternom uređaju Raspberry Pi.
// git code - po mogućnosti dela mergaj dva repozitorija

Potrebna validacija kod unosa korisničkih podataka:
https://github.com/ooad-2015-2016/MacroHard/blob/master/Projekat/ShEM/ShEM/View/Login.xaml.cs

Eksterni servisi koji se koriste su: Google Books API, OMDB API, Spotify API:
https://github.com/ooad-2015-2016/MacroHard/blob/master/Projekat/ShEM/ShEM/Helpers/MovieAPIParser.cs
https://github.com/ooad-2015-2016/MacroHard/blob/master/Projekat/ShEM/ShEM/Helpers/BookAPIParser.cs
https://github.com/ooad-2015-2016/MacroHard/blob/master/Projekat/ShEM/ShEM/Helpers/SongAPIParser.cs

Prilagođavanje mobilnom uređaju je urađeno korištenje adaptivnog layout-a, te korištenjem camere i bluetooth-a
https://github.com/ooad-2015-2016/MacroHard/blob/master/Projekat/ShEM/ShEM/Helpers/CameraHelper.cs
//ceraaa

Web servis koji pružamo klijentu je ShEMWebAPI
https://github.com/ooad-2015-2016/MacroHard/tree/master/Projekat/ShEMWebAPI
//dela trebaš dodati kod
	
