<template>
  <v-app fluid>
    <v-app-bar title="Scan Test"></v-app-bar>
    <SidebarComponent :scans="scans" @select-scan="handleScanSelect"></SidebarComponent>
    <ScanView :scan="selectedScan" @refresh-scan="reloadAndRefreshScans"></ScanView>
  </v-app>
</template>

<script setup lang="ts">
import SidebarComponent from './components/SidebarComponent.vue'
import { scanService } from './services/apiService';
import type { Scan } from './types/Scan'
import ScanView from './views/ScanView.vue'

import { onMounted, ref } from 'vue'

const scans = ref<Scan[]>([]);
const selectedScan = ref<Scan | null>(null);

const loadScans = async (): Promise<void> => {
  try {
    const response = await scanService.getAllScans();
    scans.value = response.data.map(s => ({ ...s }));
  } catch (error) {
    console.error("Failed to load scans", error);
  }
};

const refreshSelectedScan = (): void => {
  const currentId = selectedScan.value?.id;
  if (!currentId) return;

  const updated = scans.value.find(scan => scan.id === currentId);
  if (updated) {
    selectedScan.value = { ...updated }; 
  }
};

const reloadAndRefreshScans = async (): Promise<void> => {
  await loadScans();
  refreshSelectedScan();
};

const handleScanSelect = (scan: Scan) => selectedScan.value = scan;

onMounted(() => {
  loadScans();
});

</script>

<style scoped></style>
