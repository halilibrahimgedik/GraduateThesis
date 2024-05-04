using GraduateThesis.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateThesis.Repository.Seeds
{
    public class ClubSeed : IEntityTypeConfiguration<Club>
    {
        public void Configure(EntityTypeBuilder<Club> builder)
        {
            builder.HasData(
                    new Club() { Id = 1, ClubName = "DU Siber", ClubSummary = "DU Siber Kulübü, öğrencilere teknoloji, yazılım ve siber güvenlik alanlarında deneyim kazanma imkanı sunar. Atölyeler, yarışmalar ve seminerlerle öğrenme ortamı sağlar. Katılın, teknolojiye adım atın ve kendinizi geliştirin!", ClubPhoto = "default.jpg", IsClubActive = true, CreatedDate = DateTime.Now },

                    new Club() { Id = 2, ClubName = "Kitap Dostu", ClubSummary = "Kitap Dostu Kulübü, kitap tutkunlarını bir araya getirerek edebiyatın büyülü dünyasında yolculuğa çıkarır. Okuma tutkusunu paylaşan herkesi bekliyoruz!", ClubPhoto = "default.jpg", IsClubActive = true, CreatedDate = DateTime.Now },

                    new Club() { Id = 3, ClubName = "DU Archer Club", ClubSummary = "DU Archer Club, okçuluk tutkunlarının buluşma noktasıdır. Okçuluk sporuna ilgi duyan herkesi bekliyoruz! ", ClubPhoto = "default.jpg", IsClubActive = true, CreatedDate = DateTime.Now },

                    new Club() { Id = 4, ClubName = "DU Scout Club", ClubSummary = "Kulübümüz, doğayla iç içe olmayı, macera dolu anlar yaşamayı seven herkesi bir araya getiriyor. Keşfetmeye hazır mısın?  ", ClubPhoto = "default.jpg", IsClubActive = true, CreatedDate = DateTime.Now },

                    new Club() { Id = 5, ClubName = "Elit Dans Kulübü", ClubSummary = "Elit Dans Kulübü, ritim tutmayı seven herkes için mükemmel bir buluşma noktasıdır. Eğlenceli dans dersleri ve unutulmaz performanslarla dolu bir deneyim için seni de bekliyoruz! ", ClubPhoto = "default.jpg", IsClubActive = true, CreatedDate = DateTime.Now },

                    new Club() { Id = 6, ClubName = "The Young Entrepreneurs Club", ClubSummary = "Genç Girişimciler Kulübü, yenilikçi fikirleriyle öne çıkan gençleri bir araya getirir. İş dünyasına adım atmak isteyenlere mentorluk yapar ve eğitimler düzenler. İş hayatına dair her şeyi keşfetmek için seni de aramıza bekliyoruz! ", ClubPhoto = "default.jpg", IsClubActive = true, CreatedDate = DateTime.Now }

                );
        }
    }
}
