import { Building } from '../building';

export interface BuildingListResponse {
    success: boolean;
    buildings: Building[];
    count: number;
    perPage: number;
    page: number;
}