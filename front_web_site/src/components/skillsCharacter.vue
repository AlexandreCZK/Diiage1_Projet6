<template>
  <div class="table-responsive">
    <table class="table text-light">
      <thead>
        <tr>
          <th scope="col" colspan="12">
            <h1><u>Compétences</u></h1>
          </th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <th scope="row" colspan="2">Nom de compétences</th>
          <th colspan="2">Nb tour de préparation</th>
          <th colspan="2">Dommages</th>
          <th colspan="2">Niveau pour le débloquer</th>
          <th colspan="2">Cible</th>
          <th colspan="2">Emplacement de compétences</th>
        </tr>
        <tr>
          <th scope="row" colspan="2">{{ character.skill1.name }}</th>
          <th colspan="2">{{ character.skill1.nbTour }}</th>
          <th colspan="2">{{ character.skill1.dmg }}</th>
          <th colspan="2">{{ character.skill1.lvl }}</th>
          <th colspan="2">{{ character.skill1.cible }}</th>
          <th colspan="2">{{ character.skill1.emplacement }}</th>
        </tr>
        <tr>
          <th scope="row" colspan="2">{{ character.skill2.name }}</th>
          <th colspan="2">{{ character.skill2.nbTour }}</th>
          <th colspan="2">{{ character.skill2.dmg }}</th>
          <th colspan="2">{{ character.skill2.lvl }}</th>
          <th colspan="2">{{ character.skill2.cible }}</th>
          <th colspan="2">{{ character.skill2.emplacement }}</th>
        </tr>
        <tr>
          <th scope="row" colspan="2">{{ character.skill3.name }}</th>
          <th colspan="2">{{ character.skill3.nbTour }}</th>
          <th colspan="2">{{ character.skill3.dmg }}</th>
          <th colspan="2">{{ character.skill3.lvl }}</th>
          <th colspan="2">{{ character.skill3.cible }}</th>
          <th colspan="2">{{ character.skill3.emplacement }}</th>
        </tr>
        <tr>
          <th scope="row" colspan="2">{{ character.skill4.name }}</th>
          <th colspan="2">{{ character.skill4.nbTour }}</th>
          <th colspan="2">{{ character.skill4.dmg }}</th>
          <th colspan="2">{{ character.skill4.lvl }}</th>
          <th colspan="2">{{ character.skill4.cible }}</th>
          <th colspan="2">{{ character.skill4.emplacement }}</th>
        </tr>
        <tr>
          <th scope="row" colspan="2">{{ character.skill5.name }}</th>
          <th colspan="2">{{ character.skill5.nbTour }}</th>
          <th colspan="2">{{ character.skill5.dmg }}</th>
          <th colspan="2">{{ character.skill5.lvl }}</th>
          <th colspan="2">{{ character.skill5.cible }}</th>
          <th colspan="2">{{ character.skill5.emplacement }}</th>
        </tr>
        <tr>
          <th scope="row" colspan="2">{{ character.skill6.name }}</th>
          <th colspan="2">{{ character.skill6.nbTour }}</th>
          <th colspan="2">{{ character.skill6.dmg }}</th>
          <th colspan="2">{{ character.skill6.lvl }}</th>
          <th colspan="2">{{ character.skill6.cible }}</th>
          <th colspan="2">{{ character.skill6.emplacement }}</th>
        </tr>
      </tbody>
    </table>
  </div>
</template>
<script>
export default {
  data(){
    switch (this.classChoose) {
        case "Warrior":
          this.character = {
            skill1: {
              name: "Shiled Strike",
              nbTour: 0,
              dmg: "Strengh * 1.5",
              lvl: 1,
              cible: "Single-target",
              emplacement: "Skill 1",
            },
            skill2: {
              name: "Thunder Clap",
              nbTour: 1,
              dmg: "Strengh * 1,4",
              lvl: 10,
              cible: "Multi-Target",
              emplacement: "Skill 2",
            },
            skill3: {
              name: "Revenge",
              nbTour: 2,
              dmg: "Strengh * 2",
              lvl: 20,
              cible: "Single-Traget",
              emplacement: "Skill 3",
            },
            skill4: {
              name: "Devastate",
              nbTour: 0,
              dmg: "Strengh * 1,8",
              lvl: 30,
              cible: "Single-target",
              emplacement: "Skill 1",
            },
            skill5: {
              name: "Multiple shots",
              nbTour: 1,
              dmg: "Strengh*1,6",
              lvl: 40,
              cible: "Multi-target",
              emplacement: "Skill 2",
            },
            skill6: {
              name: "Slay",
              nbTour: 2,
              dmg: "Strengh*2,4",
              lvl: 50,
              cible: "Multi-target",
              emplacement: "Skill 3",
            },
          };
          break;
        case "Shaman":
          this.character = {
            skill1: {
              name: "Flame Shock",
              nbTour: 0,
              dmg: "intelligence*1,4",
              lvl: 1,
              cible: "Single target",
              emplacement: "Skill 1",
            },
            skill2: {
              name: "Lightning",
              nbTour: 1,
              dmg: "intelligence*1,3",
              lvl: 10,
              cible: "Single target",
              emplacement: "Skill 2",
            },
            skill3: {
              name: "Lightning chain",
              nbTour: 2,
              dmg: "intelligence*2,1",
              lvl: 20,
              cible: "Multi-target",
              emplacement: "Skill 3",
            },
            skill4: {
              name: "Ancestral spirit",
              nbTour: 1,
              dmg: "intelligence*4",
              lvl: 30,
              cible: "Characters",
              emplacement: "Skill 1",
            },
            skill5: {
              name: "Earthquake",
              nbTour: 2,
              dmg: "intelligence*1,5",
              lvl: 40,
              cible: "Multi-target",
              emplacement: "Skill 2",
            },
            skill6: {
              name: "Lava explosion",
              nbTour: 3,
              dmg: "intelligence*2,4",
              lvl: 50,
              cible: "Single target",
              emplacement: "Skill 3",
            },
          };
          break;
        case "Wizard":
          this.character = {
            skill1: {
              name: "Fire bold",
              nbTour: 0,
              dmg: "ntelligence * 1,3",
              lvl: 1,
              cible: " Single target",
              emplacement: "Skill 1",
            },
            skill2: {
              name: "Frosted bold",
              nbTour: 1,
              dmg: "Intelligence * 1,5",
              lvl: 10,
              cible: "Single target",
              emplacement: "Skill 2",
            },
            skill3: {
              name: "Arcane explosion",
              nbTour: 2,
              dmg: "Intelligence * 2,1",
              lvl: 20,
              cible: "Multi-target",
              emplacement: "Skill 3",
            },
            skill4: {
              name: "Frosted nova",
              nbTour: 0,
              dmg: "Intelligence * 1,2",
              lvl: 30,
              cible: "Multi-target",
              emplacement: "Skill 1",
            },
            skill5: {
              name: "Arcane projectiles",
              nbTour: 1,
              dmg: "Intelligence * 2,1",
              lvl: 40,
              cible: "Single target",
              emplacement: "Skill 2",
            },
            skill6: {
              name: "Fire explosion",
              nbTour: 2,
              dmg: "Intelligence * 2,6",
              lvl: 50,
              cible: "Multi-target",
              emplacement: "Skill 3",
            },
          };
          break;
        case "Gobelin":
          this.character = {
            skill1: {
              name: "Dynamite stick",
              nbTour: 0,
              dmg: "Agility * 1,2",
              lvl: 1,
              cible: "Single target",
              emplacement: "Skill 1",
            },
            skill2: {
              name: "Hydroglycerin",
              nbTour: 1,
              dmg: "Agility * 0,5",
              lvl: 10,
              cible: "Multi-target",
              emplacement: "Skill 2",
            },
            skill3: {
              name: "Bomba explosive",
              nbTour: 2,
              dmg: "Agility * 0,9",
              lvl: 20,
              cible: "Multi-target",
              emplacement: "Skill 3",
            },
            skill4: {
              name: "Grenade",
              nbTour: 0,
              dmg: "Agility * 1,1",
              lvl: 30,
              cible: "Multi-target",
              emplacement: "Skill 1",
            },
            skill5: {
              name: "Death ray",
              nbTour: 1,
              dmg: "Agility * 1,7",
              lvl: 40,
              cible: "Single target",
              emplacement: "Skill 2",
            },
            skill6: {
              name: "Sheep explosive",
              nbTour: 2,
              dmg: "Agility * 1,5",
              lvl: 50,
              cible: "Multi-target",
              emplacement: "Skill 3",
            },
          };
          break;
        case "Necromancian":
            this.character = {
            skill1: {
              name: "Sword Strike",
              nbTour: 0,
              dmg: "Intelligence * 0,8",
              lvl: 1,
              cible: "Single target",
              emplacement: "Skill 1",
            },
            skill2: {
              name: "Purulent strike",
              nbTour: 1,
              dmg: "Intelligence * 1,2",
              lvl: 10,
              cible: "Single target",
              emplacement: "Skill 2",
            },
            skill3: {
              name: "Soul Reaper",
              nbTour: 2,
              dmg: "Intelligence * 0,8",
              lvl: 20,
              cible: "Multi-target",
              emplacement: "Skill 3",
            },
            skill4: {
              name: "Death grip",
              nbTour: 0,
              dmg: "Intelligence * 1,1",
              lvl: 30,
              cible: "Multi-target",
              emplacement: "Skill 1",
            },
            skill5: {
              name: "Bone storm",
              nbTour: 1,
              dmg: "Intelligence * 1,3",
              lvl: 40,
              cible: "Multi-target",
              emplacement: "Skill 2",
            },
            skill6: {
              name: "Blood Pact",
              nbTour: 2,
              dmg: "Intelligence * 1,5",
              lvl: 50,
              cible: "Single target / Heal",
              emplacement: "Skill 3",
            },
          };
          break;
        case "Orc":
            this.character = {
            skill1: {
              name: "Sword Strike",
              nbTour: 0,
              dmg: "Strength * 0,7",
              lvl: "1",
              cible: "Single target",
              emplacement: "Skill 1",
            },
            skill2: {
              name: "Notch",
              nbTour: 1,
              dmg: "Strength * 0,6",
              lvl: 10,
              cible: "Multi-target",
              emplacement: "Skill 2",
            },
            skill3: {
              name: "Deadly Bite",
              nbTour: 2,
              dmg: "Strength * 1,6",
              lvl: 20,
              cible: "Single target",
              emplacement: "Skill 3",
            },
            skill4: {
              name: "Abyssal Strike",
              nbTour: 0,
              dmg: "Strength * 1,2",
              lvl: 30,
              cible: "Single target",
              emplacement: "Skill 1",
            },
            skill5: {
              name: "Dealdy Sweep",
              nbTour: 1,
              dmg: "Strength * 1,5",
              lvl: 40,
              cible: "Multi-target",
              emplacement: "Skill 2",
            },
            skill6: {
              name: "Sword throwing",
              nbTour: 2,
              dmg: "Strength * 2,5",
              lvl: 50,
              cible: "Multi-target",
              emplacement: "Skill 3",
            },
          };
          break;
    }
    return this.character
  },
  props: {
    classChoose: {
      type: String,
      required: true,
    },
  }
};
</script>
<style scoped>
</style>