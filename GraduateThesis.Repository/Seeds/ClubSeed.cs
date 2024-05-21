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
                    new Club() { Id = 1, Name = "DU Siber", Summary = "DU Siber Kulübü, öğrencilere teknoloji, yazılım ve siber güvenlik alanlarında deneyim kazanma imkanı sunar. Atölyeler, yarışmalar ve seminerlerle öğrenme ortamı sağlar. Katılın, teknolojiye adım atın ve kendinizi geliştirin!", UniversityId = 60, Url = "default.jpg", IsActive = true, CreatedDate = DateTime.Now },

                    new Club() { Id = 2, Name = "Kitap Dostu", Summary = "Kitap Dostu Kulübü, kitap tutkunlarını bir araya getirerek edebiyatın büyülü dünyasında yolculuğa çıkarır. Okuma tutkusunu paylaşan herkesi bekliyoruz!", UniversityId = 60, Url = "default.jpg", IsActive = true, CreatedDate = DateTime.Now },

                    new Club() { Id = 3, Name = "DU Archer Club", Summary = "DU Archer Club, okçuluk tutkunlarının buluşma noktasıdır. Okçuluk sporuna ilgi duyan herkesi bekliyoruz! ", UniversityId = 60, Url = "default.jpg", IsActive = true, CreatedDate = DateTime.Now },

                    new Club() { Id = 4, Name = "DU Scout Club", Summary = "Kulübümüz, doğayla iç içe olmayı, macera dolu anlar yaşamayı seven herkesi bir araya getiriyor. Keşfetmeye hazır mısın?", UniversityId = 60, Url = "default.jpg", IsActive = true, CreatedDate = DateTime.Now },

                    new Club() { Id = 5, Name = "Elit Dans Kulübü", Summary = "Elit Dans Kulübü, ritim tutmayı seven herkes için mükemmel bir buluşma noktasıdır. Eğlenceli dans dersleri ve unutulmaz performanslarla dolu bir deneyim için seni de bekliyoruz!", UniversityId = 60, Url = "default.jpg", IsActive = true, CreatedDate = DateTime.Now },

                    new Club() { Id = 6, Name = "The Young Entrepreneurs Club", Summary = "Genç Girişimciler Kulübü, yenilikçi fikirleriyle öne çıkan gençleri bir araya getirir. İş dünyasına adım atmak isteyenlere mentorluk yapar ve eğitimler düzenler. İş hayatına dair her şeyi keşfetmek için seni de aramıza bekliyoruz!", UniversityId = 60, Url = "default.jpg", IsActive = true, CreatedDate = DateTime.Now }

                );
        }
    }
}
