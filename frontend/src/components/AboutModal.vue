<template>
  <v-dialog v-model="showDialog" width="550">
    <template v-slot:activator="{ isActive }">
      <v-btn :ripple="false" icon flat v-bind="isActive" @click="showDialog = true">
        <v-icon class=""> mdi-information </v-icon>
      </v-btn>
    </template>
    
    <v-card>
      <v-card-title>
        <span>About</span>
      </v-card-title>
      <v-card-text class="text-center">
        Tacly is a multiplayer competitive tic tac toe game. Add your friends and play!!
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn elevation="2" color="green darken-1" href="https://github.com/japankid-code/tacly">learn more</v-btn>
        <v-btn dark elevation="2" color="green darken-1" text @click="showDialog = false">Close</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
export default {
  name: "AboutModal",
  data () {
    return {
      showDialog: false,
    }
  },
};
</script>

<style scoped lang="scss">
</style>
