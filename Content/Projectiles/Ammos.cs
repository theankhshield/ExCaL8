using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;

namespace ExCaL8.Content.Projectiles.Ammos;

public class Bullet : ModProjectile
{
    public override string Texture => "Terraria/Images/Projectile_" + ProjectileID.Bullet;
    public override void SetDefaults()
    {
        Projectile.CloneDefaults(ProjectileID.Bullet);
        Projectile.friendly = true;
        Projectile.hostile = true;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.penetrate = 5; 
        Projectile.timeLeft = 60; 
        Projectile.light = 0.5f;
        Projectile.extraUpdates = 1; 
        
        AIType = ProjectileID.Bullet; 
    }
    
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        Projectile.velocity = oldVelocity * 0.25f;
        return false;
    }
}