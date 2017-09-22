using System.Collections.Generic;
using AuthorizationLab.Core.Models;

namespace AuthorizationLab.Core {
    public interface IDocumentRepository {
        IEnumerable<Document> GetDocuments();
        Document GetDocument(int id);
    }
}
