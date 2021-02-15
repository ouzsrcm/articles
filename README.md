# articles
Değerlendirme projesi

# Projede kullanıdığınız tasarım desenleri hangileridir? Bu desenleri neden kullandınız? 

1. Generic Repository:  Bunun nedeni CRUD işlemlerimi generic hale getirmek. Her veritabanı tablosu için ayrı objeler yaratmaktansa onları Type olarak Generip Repo üzerinde işlemek daha mantıklı olacaktır.
2. Service Layer: Birden fazla repo ile çalışmak, validasyon yapmak, exception yönetimi sağlamak, WCF yada REST servislerinde sürecin içine dahil olması, authorization, gibi karmaşık süreçleri repo yada api/app seviyesinde yapmaktansa hem geliştirilebilirliğin artması, projenin değişime kapalı olması, modüler olması objeler arasındaki bağımlılıkların en alt seviyede olması gibi bir çok faydanın olacağı bu layer'ı kullandım.
3. DTO: (Data Transfer Object): Doğrudan DB entity'sini değilde DB entity'sinin property olarak dengi olan ...DTO şeklinde isimlendirdiğim veri taşıma objelerini kullandım. Böylelikle entity'ler doğrudan başka bir katmana açılmamış oldu ve service layer'da yapamadığım spesifik validasyonları da bu objelerde property'bazlı yada model bazlı yapabildim. Entity'ler ile DTO'lar arasındaki mapping işlemi için bir mapping lib.(AutoMapper) kullandım.
4. Bu projede ihtiyaç olmadığı için o api layer'ı olduğu için gibi bıraktım.

# Kullandığınız teknoloji ve kütüphaneler hakkında daha önce tecrübeniz oldu mu? Tek tek
yazabilir misiniz?

1. EF, EFCore: Asp.net projelerimde EF, netcore projelerim de ise EFCore'u sıklıkla kullanıyorum. Muadillerinden olan Dapper'ı da kullanmıştım ama ef bende bir alışkanlık oluşturdu.
2. AutoMapper: Dto kullandığım projelerin tamamında kullanıyorum. Manual mapping yerine iyi bir tercih. Bir defa da Tinymapper kullandım.
3. Log için ise genelde log4net tercih ediyordum simple olduğu için ama serilog'u da bu projede denemiş oldum. Her ne kadar detaylı bir kullanım yapmasamda iyi bir deneyim oldu.
4. Genelde CodeFirst yaklaşımını benimsedim. Bunun nedeni her şeye hakim olabiliyorum. DB bağımlı olmak günümüz yazılım dünyasında pek nahoş geliyor bana. Bunun sebebi artık distributed app'ler ve birbirleri ile anlık haberleşen api'ler olabilir.
5. T-SQL ve PL/SQL konusunda bir uzmanlığım olsa da SQL ile db oluşturmak yerine burda efcore-tools'u yükledim projeye bi update-database cmd sayesinde db provider'ı ayarlandıktan sonra şurada(https://docs.microsoft.com/tr-tr/ef/core/providers/?tabs=dotnet-core-cli) desteklenen provider'lardan biri kullanılarak istenilen rdbms/nosql db ile çalışılabilir. Bu beni çok heyecanlandırıyor açıkcası.
6. Cache için ise proje boyutuna bakıldığında yeterli olacağını düşündüğüm memoryCache kullandım. Varolan projelerimde aslında redis tercih ediyorum ama burda bu ext. yeterli oldu.
7. Proje de api test'leri, debug'lar ve ui-dev'i sürecinde kullanılacak modeller için ui-dev'e fikir verecek bir lib. olan swagger kurdum.

# Daha geniş vaktiniz olsaydı projeye neler eklemek isterdiniz?

1. Öncelikle Serilog lib.'in File sink'i yerine db ve Seq kurar onuda SignalR ile bir dashboard'a bağlar anlık verileri izlerdim. Böylelikle Release izleme çopk daha eğlenceli bir hal alırdı.
2. Service layer'ı multi-db çalışacak şekilde revize ederdim.
3. Apilayer için mediatr kullanırdım.
4. Cache için redis kullanırdım.
