using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationLab.Core;
using AuthorizationLab.Core.Models;

namespace AuthorizationLab.Persistence {
    public class DocumentRepository : IDocumentRepository {
        protected static readonly List<Document> _documents = new List<Document> {
            new Document {Id = 1, Author = "Alex"},
            new Document {Id = 2, Author = "Alexa"}
        };

        public virtual IEnumerable<Document> GetDocuments() {
            return _documents;
        }

        public virtual Document GetDocument(int id) {
            return (_documents.FirstOrDefault(d => d.Id == id));
        }
    }
}
