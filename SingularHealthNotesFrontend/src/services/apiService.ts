import type { Note, Scan } from "@/types/Scan";
import axios, { type AxiosResponse } from "axios";

const apiClient = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

export const scanService = {
    getAllScans(): Promise<AxiosResponse<Scan[]>> {
      return apiClient.get<Scan[]>("/scans");
    },
  
    getNotes(scanId: string): Promise<AxiosResponse<Note[]>> {
      return apiClient.get<Note[]>(`/scans/${scanId}/notes`);
    },
  
    updateScan(scanId: string, scanData: Scan): Promise<AxiosResponse<void>> {
      return apiClient.post<void>(`/scans/${scanId}/notes`, scanData);
    },
  };