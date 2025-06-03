<template>
  <v-navigation-drawer>
    <v-list-item title="Scans"></v-list-item>
    <v-divider></v-divider>
    <v-list-item
      v-for="scan in scans"
      :key="scan.id"
      :title="scan.name"
      @click="$emit('select-scan', scan)"
    />
  </v-navigation-drawer>
</template>

<script setup lang="ts">
import type { Scan } from '@/types/Scan';

const props = defineProps<{
  scans: Scan[];
}>();

</script>
