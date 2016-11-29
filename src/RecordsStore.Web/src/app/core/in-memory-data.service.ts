import { InMemoryDbService } from 'angular-in-memory-web-api';

import { Record } from '../records/shared/record.model';

export class InMemoryDataService implements InMemoryDbService {
    createDb() {
        let records: Record[] = [
            { id: 1, title: 'Diabolica', releaseYear: 2016, price: 20, bandId: 1 },
            { id: 2, title: 'Primal Fear', releaseYear: 2006, price: 20, bandId: 2 },
            { id: 3, title: 'Legendary Tales', releaseYear: 2006, price: 20, bandId: 3 },
            { id: 4, title: 'Glory To The Brave', releaseYear: 2006, price: 20, bandId: 4 },
            { id: 5, title: 'Rust In Peace', releaseYear: 2006, price: 20, bandId: 5 }
        ];

        let bands = [
            { id: 1, name: 'Iron Mask' },
            { id: 2, name: 'Primal Fear' },
            { id: 3, name: 'Rhapsody' },
            { id: 4, name: 'HammerFall' },
            { id: 5, name: 'Megadeth' }
        ];

        return { records, bands };
    }
}
